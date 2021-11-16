using Microsoft.Extensions.DependencyInjection;
using RestaurantSystem.DataAccessLayer.Repositories.Abstraction;
using RestaurantSystem.DataAccessLayer.Repositories.Realisation.EFRealisation;
using RestaurantSystem.DataAccessLayer.UnitOfWork.Abstraction;
using RestaurantSystem.DataAccessLayer.UnitOfWork.Realisation.EFRealisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer
{
    public static class DependenciesEFData
    {
        public static IServiceCollection SetEFDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<RestorauntDbContext>();
            services.AddScoped<IBasketRepository, EFBasketRepository>();
            services.AddScoped<IDishRepository, EFDishRepository>();
            services.AddScoped<IDishTypeRepository, EFDishTypeRepository>();
            services.AddScoped<IIngradientRepository, EFIngradientRepository>();
            services.AddScoped<IDishInBasketRepository, EFDishInBasketRepository>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            return services;
        }
    }
}
