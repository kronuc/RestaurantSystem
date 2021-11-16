using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Abstraction
{
    public interface IDishInBasketRepository : IRepository<DishInBasketEntity, int>
    {
        public void RemooveDishFromBasket(int basketId, int DishId);
    }
}
