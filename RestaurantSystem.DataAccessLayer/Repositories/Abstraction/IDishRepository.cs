using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Abstraction
{
    public interface IDishRepository : IRepository<DishEntity, int>
    {
        public IEnumerable<DishEntity> GetDishByType(int typeId);
        public IEnumerable<DishEntity> GetDishEntitiesInBasket(int basketId);
    }
}
