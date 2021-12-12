using ClientApi.Application.Services;
using ClientApi.Core.Interfaces;
using ClientApi.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApi.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManageCityService, ManageCityService>();
            services.AddScoped<IManageClientService, ManageClientService>();
        }
    }
}
