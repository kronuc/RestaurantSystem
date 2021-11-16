using RestaurantSystem.DataAccessLayer.UnitOfWork.Abstraction;
using RestaurantSystem.DataModel;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Implementation
{
    public class DishService : IDishService<int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Dish<int>> FindDishByType(DishType<int> type)
        {
            var result =  _unitOfWork
                .DishRepository
                .GetDishByType(type.Id)
                .Select(dish => dish.ToModelEntity())
                .ToList();

            return result;
        }

        public Dish<int> GetDishById(int id)
        {
            var result = _unitOfWork.DishRepository.GetById(id).ToModelEntity();
            return result;
        }
    }
}
