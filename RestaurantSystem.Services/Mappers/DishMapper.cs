using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Mappers
{
    public static class DishMapper
    {
        public static Dish<int> ToModelEntity(this DishEntity dishDbEntity)
        {
            var dishModelEntity = new Dish<int>()
            {
                Id = dishDbEntity.Id,
                TypeId = dishDbEntity.DishTypeEntityId,
                Price = dishDbEntity.Price,
                Weight = dishDbEntity.Weight
            };

            return dishModelEntity;
        }

        public static DishEntity ToDbEntity(this Dish<int> dishModelEntity)
        {
            var dishDbEntity = new DishEntity()
            {
                Id = dishModelEntity.Id,
                DishTypeEntityId = dishModelEntity.TypeId,
                Price = dishModelEntity.Price,
                Weight = dishModelEntity.Weight
            };
            return dishDbEntity;
        }
    }
}
