using ClientApi.Infrastructure.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApi.Configurations
{
    public static class MiddlewaresSetup
    {
        public static void AddMiddlewareSetup(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                        options.SuppressModelStateInvalidFilter = true
                    );

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ValidatorFilter>();
            });
        }
    }
}
