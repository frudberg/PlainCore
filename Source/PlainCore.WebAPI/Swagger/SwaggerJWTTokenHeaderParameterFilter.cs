using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Swagger
{
    public class SwaggerJWTTokenHeaderParameterFilter : IOperationFilter
    {
        private string defaultResourceUrl;
        public SwaggerJWTTokenHeaderParameterFilter(string defaultResourceUrl)
        {
            this.defaultResourceUrl = defaultResourceUrl;
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            if (operation.OperationId.Contains("LoginPost"))
            {
                operation.Produces.Add("application/json");
                operation.Consumes.Add("application/x-www-form-urlencoded");

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Content-Type",
                    In = "header",
                    Required = true,
                    Description = "Content-Type",
                    Type = "string",
                    Default = "application/x-www-form-urlencoded"
                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "scope",
                    In = "formData",
                    Required = true,
                    Type = "string",
                    Default = "offline_access profile email roles"
                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "resource",
                    In = "formData",
                    Required = true,
                    Type = "string",
                    Default = defaultResourceUrl

                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "grant_type",
                    In = "formData",
                    Required = true,
                    Type = "string",
                    Default = "password",
                    Description = "\"password\" and \"refresh_token\": \n - \"password\" => username, password. \n - \"refresh_token\" => refresh_token."
                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "username",
                    In = "formData",
                    Type = "string"
                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "password",
                    In = "formData",
                    Type = "string"
                });
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "refresh_token",
                    In = "formData",
                    Type = "string"
                });
            }
        }
    }
}
