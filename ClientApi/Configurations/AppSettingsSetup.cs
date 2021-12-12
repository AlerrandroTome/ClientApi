using ClientApi.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClientApi.Configurations
{
    public static class AppSettingsSetup
    {
        public static void AddAppSettingsSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnStringSettings>(configuration.GetSection(nameof(ConnStringSettings)));
            services.AddSingleton<IConnStringSettings>(x => x.GetRequiredService<IOptions<ConnStringSettings>>().Value);
        }
    }
}
