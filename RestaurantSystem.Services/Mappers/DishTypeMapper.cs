using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Mappers
{
    public static class DishTypeMapper
    {
        public static DishType<int> ToModelEntity(this DishTypeEntity dishTypeDbEntity)
        {
            var dishTypeModelEntity = new DishType<int>()
            {
                Id = dishTypeDbEntity.Id,
                Description = dishTypeDbEntity.Description,
                Name = dishTypeDbEntity.Name
            };

            return dishTypeModelEntity;
        }
    }
}
