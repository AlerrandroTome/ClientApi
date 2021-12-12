using ClientApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApi.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, string connString)
        {
            services.AddDbContext<ClientContext>(options =>
                options.UseSqlServer(connString)
            );
        }
    }
}
