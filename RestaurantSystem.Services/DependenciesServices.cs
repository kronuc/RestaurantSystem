using Microsoft.Extensions.DependencyInjection;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services
{
    public static class DependenciesServices
    {
        public static IServiceCollection SetServices(this IServiceCollection services)
        {
            services.AddScoped<IBasketService<int>, BasketService>();
            services.AddScoped<IDishService<int>, DishService>();
            services.AddScoped<IDishTypeService<int>, DishTypeService>();
            services.AddScoped<IIngredientService<int>, IngredientService>();
            return services;
        }
    }
}
