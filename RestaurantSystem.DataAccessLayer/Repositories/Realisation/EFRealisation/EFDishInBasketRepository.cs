using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataAccessLayer.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Realisation.EFRealisation
{
    public class EFDishInBasketRepository : EFGenericRepository<DishInBasketEntity, int>, IDishInBasketRepository
    {
        public EFDishInBasketRepository(RestorauntDbContext dbContext) : base(dbContext, dbContext.DishInBaskets)
        {
        }

        public void RemooveDishFromBasket(int basketId, int dishId)
        {
            var dishInBasketForRemooving = _dbContext
                .DishInBaskets
                .Where(dishInBasket => dishInBasket.DishEntityId == dishId & dishInBasket.BasketEntityId == basketId)
                .FirstOrDefault();
            _dbContext.DishInBaskets.Remove(dishInBasketForRemooving);        }
    }
}
