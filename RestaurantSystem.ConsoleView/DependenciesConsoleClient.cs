using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ConsoleView
{
    public static class DependenciesConsoleClient
    {
        public static IServiceCollection SetConsoleClientDependencies(this IServiceCollection services)
        {
            services.AddSingleton<DishInformaitonPage>();
            services.AddSingleton<DishesPage>();
            services.AddSingleton<BasketPage>();
            services.AddSingleton<MainMenuPage>();
            services.AddSingleton<ConsoleClient>();
            return services;
        }
    }
}
