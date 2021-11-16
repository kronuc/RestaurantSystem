using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Mappers
{
    public static class BasketMapper
    {
        public static Basket<int> ToModelEntity(this BasketEntity basketDbEntity)
        {
            var dishTypeModelEntity = new Basket<int>()
            {
                Id = basketDbEntity.Id,
                UserName = basketDbEntity.UserName
            };

            return dishTypeModelEntity;
        }

        public static BasketEntity ToDbntity(this Basket<int> dishTypeModelEntity)
        {
            var basketDbEntity = new BasketEntity()
            {
                Id = dishTypeModelEntity.Id,
                UserName = dishTypeModelEntity.UserName
            };

            return basketDbEntity;
        }
    }
}
