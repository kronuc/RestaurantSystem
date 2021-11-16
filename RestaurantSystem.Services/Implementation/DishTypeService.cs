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
    public class DishTypeService : IDishTypeService<int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DishType<int>> GetAllDishTypes()
        {
            var result = _unitOfWork
                .DishTypeRepository
                .GetAll()
                .Select(entity => entity.ToModelEntity())
                .ToList();
            return result;
        }

        public DishType<int> GetDishTypeById(int id)
        {
            var result = _unitOfWork
                .DishTypeRepository
                .GetById(id)
                .ToModelEntity();
            return result;
        }

        public IEnumerable<DishType<int>> GetDishTypesByName(string name)
        {
            var resutl = _unitOfWork
                .DishTypeRepository
                .GetDishTypeByName(name)
                .Select(dishType => dishType.ToModelEntity());
            return resutl;
        }
    }
}
