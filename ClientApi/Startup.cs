using ClientApi.Configurations;
using ClientApi.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ClientApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = new ConnStringSettings();
            Configuration.Bind(key: nameof(connectionStrings), connectionStrings);

            services.AddJsonSetup();

            services.AddRouting();

            services.AddOdataSetup();

            services.AddAppSettingsSetup(Configuration);

            services.AddDependencyInjectionSetup();

            services.AddDatabaseSetup(connectionStrings.ConnString);

            services.AddAutoMapper(typeof(Infrastructure.AutoMapper.AutoMapper));

            services.AddMiddlewareSetup();

            services.AddFluentValidationSetup();

            services.AddControllers();

            services.AddSwaggerSetup();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerSetup();

            app.UseOdataSetup();
        }
    }
}
