using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ClientApi.Configurations
{
    public static class SwaggerSettings
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "The Client Api",
                    Version = "v1",
                    Description = "ClientApi's documentation."
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientApi v1"));
        }
    }
}
