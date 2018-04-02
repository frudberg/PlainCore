using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Infrastructure.DAL.EF;
using PlainCore.Infrastructure.Identities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Identity;
using StructureMap;
using PlainCore.WebAPI.IoC;
using PlainCore.WebAPI.Swagger;
using Microsoft.EntityFrameworkCore;
using PlainCore.WebAPI.Authentication;
using PlainCore.Infrastructure.Messages;
using PlainCore.Core.Externals.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PlainCore.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<UnitOfWork>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseOpenIddict();
            });

            services.AddSiteAuthorization(Configuration);
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            // add identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<UnitOfWork>()
                .AddUserManager<ApplicationUserManager>()
                .AddUserStore<ApplicationUserStoreDecorator>()
                .AddRoleStore<ApplicationRoleStoreDecorator>()
                .AddDefaultTokenProviders();

            services.AddSwaggerConfiguration(Configuration);

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            services.Configure<SendGridEmailSenderOptions>(Configuration.GetSection("SendGridEmailSenderOptions"));
            return this.ConfigureIoC(services);
        }

        public virtual IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = StructureMapContainerInit.InitializeContainer();
            container.Inject<IConfigurationRoot>(Configuration);
            container.Inject<IConfiguration>(Configuration);
            container.Populate(services);
            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IContainer container)
        {
            app.UseAuthentication();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseHttpMethodOverride();

            if (env.IsDevelopment())
            {
                var unitOfWork = container.GetInstance<UnitOfWork>();
                if (!unitOfWork.AllMigrationsApplied())
                {
                    unitOfWork.Database.Migrate();
                    unitOfWork.EnsureSeeded(container);
                }
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlainCore API V1");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
