using System;
using Microsoft.Extensions.DependencyInjection;
using RestaurantSystem.ConsoleView;
using RestaurantSystem.DataAccessLayer;
using RestaurantSystem.Services;

namespace RestaurantSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.SetEFDataDependencies();
            services.SetServices();
            services.SetConsoleClientDependencies();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ConsoleClient client = serviceProvider.GetRequiredService<ConsoleClient>();
            client.Start();
        }
    }
}
