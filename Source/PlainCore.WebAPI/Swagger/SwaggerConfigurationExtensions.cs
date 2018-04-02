using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerJWTTokenHeaderParameterFilter>(Configuration["JwtBearerOptions:Audience"]);
            });
            return services;
        }
    }
}
