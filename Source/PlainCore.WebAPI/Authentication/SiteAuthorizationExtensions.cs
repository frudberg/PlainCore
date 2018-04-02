using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using AspNet.Security.OpenIdConnect.Primitives;
using System.Security.Claims;
using System.Threading.Tasks;
using PlainCore.Infrastructure.DAL.EF;
using System.Net;

namespace PlainCore.WebAPI.Authentication
{
    public static class SiteAuthorizationExtensions
    {
        public static IServiceCollection AddSiteAuthorization(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("API", policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireAssertion(handler =>
                    {
                        return !handler.User.Claims.Any() || (DateTimeOffset.Now < DateTimeOffset.FromUnixTimeSeconds(long.Parse(handler.User.Claims.SingleOrDefault(x => x.Type == OpenIdConnectConstants.Claims.ExpiresAt).Value)));
                    })
                    .Build();
                });
            });

            var jwtBearerOptions = Configuration.GetSection(nameof(JwtBearerOptions));
            var openIddictSetting = Configuration.GetSection("OpenIddictSetting");

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(o =>
            {
                o.IncludeErrorDetails = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = OpenIdConnectConstants.Claims.Role,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:55906/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(openIddictSetting.GetValue<string>("SigningKey"))),
                    RequireExpirationTime = true
                };

                o.RequireHttpsMetadata = jwtBearerOptions.GetValue<bool>(nameof(JwtBearerOptions.RequireHttpsMetadata));
                o.Authority = jwtBearerOptions.GetValue<string>(nameof(JwtBearerOptions.Authority));
                o.Audience = jwtBearerOptions.GetValue<string>(nameof(JwtBearerOptions.Audience));
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " + c.Exception.Message);
                        c.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = c =>
                    {
                        Console.WriteLine("OnChallenge: " + c.ToString());
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = c =>
                    {
                        Console.WriteLine("OnTokenValidated: " +
                                    c.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddOpenIddict()
               .AddEntityFrameworkCoreStores<UnitOfWork>()
               .AddMvcBinders()
               .DisableHttpsRequirement()
               .EnableTokenEndpoint(openIddictSetting.GetValue<string>("EnableTokenEndpoint"))
               .EnableLogoutEndpoint(openIddictSetting.GetValue<string>("EnableRevocationEndpoint"))
               .EnableUserinfoEndpoint("/api/userinfo")
               .AllowPasswordFlow()
               .AllowRefreshTokenFlow()
               .UseJsonWebTokens()
               .AddSigningKey(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(openIddictSetting.GetValue<string>("SigningKey"))))

               .Configure(configuration =>
               {
                   configuration.AccessTokenLifetime = TimeSpan.FromMinutes(Configuration.GetSection("AppSetting").GetValue<double>("AccessTokenLifetimeInMinute"));
                   configuration.RefreshTokenLifetime = TimeSpan.FromMinutes(Configuration.GetSection("AppSetting").GetValue<double>("RefreshTokenLifetimeInMinute"));
                   configuration.UseRollingTokens = true;
               });

            return services;
        }
    }
}