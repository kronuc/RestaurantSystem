using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Mappers
{
    public static class IngradientMapper
    {
        public static Ingredient<int> ToModelEntity(this IngredientEntity ingredientDbEntity)
        {
            var ingredientModelEntity = new Ingredient<int>()
            {
                Id = ingredientDbEntity.Id,
                Decription = ingredientDbEntity.Decription,
                Name = ingredientDbEntity.Name,
                DishId = ingredientDbEntity.DishEntityId
            };

            return ingredientModelEntity;
        }
    }
}
