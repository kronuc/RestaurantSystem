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
    public class IngredientService : IIngredientService<int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Ingredient<int>> GetAllIngredientInDish(int dishId)
        {
            var result = _unitOfWork
                .IngradientRepository
                .GetIngredientInDish(dishId)
                .Select(intgradient => intgradient.ToModelEntity());
            return result;
        }

        public Ingredient<int> GetIngredientById(int id)
        {
            var resutl = _unitOfWork
                .IngradientRepository
                .GetById(id)
                .ToModelEntity();
            return resutl;
        }
    }
}
