using RestaurantSystem.DataAccessLayer.Repositories.Abstraction;
using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Realisation.EFRealisation
{
    public class EFDishRepository : EFGenericRepository<DishEntity, int>, IDishRepository
    {
        public EFDishRepository(RestorauntDbContext dbContext) : base(dbContext, dbContext.Dishes)
        {
            
        }

        public IEnumerable<DishEntity> GetDishByType(int typeId)
        {
            var result = _dbContext
                .Set<DishEntity>()
                .Where(dish => dish.DishTypeEntityId == typeId)
                .ToList();
            return result;
        }

        public IEnumerable<DishEntity> GetDishEntitiesInBasket(int basketId)
        {
            var result = _dbContext
                .DishInBaskets
                .Where(dishInBasket => dishInBasket.BasketEntityId == basketId)
                .Join(_dbContext.Dishes,
                    dishInBasket => dishInBasket.DishEntityId,
                    dish => dish.Id,
                    (dishInBasket, dish) => dish)
                .ToList();
            return result;
        }
    }
}
