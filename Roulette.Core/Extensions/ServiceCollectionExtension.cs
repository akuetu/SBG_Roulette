using Microsoft.Extensions.DependencyInjection;
using Roulette.Service.Services;

namespace Roulette.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRouletteServiceCollection(this IServiceCollection services)
        {
            services.AddTransient<IRouletteService, RouletteService>();
            services.AddTransient<IAccountService, AccountService>();
            return services;
        }
    }
}
