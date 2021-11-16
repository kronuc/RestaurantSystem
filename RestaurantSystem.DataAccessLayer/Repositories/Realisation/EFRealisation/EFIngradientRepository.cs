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
    public class EFIngradientRepository : EFGenericRepository<IngredientEntity, int>, IIngradientRepository
    {
        public EFIngradientRepository(RestorauntDbContext dbContext) : base(dbContext, dbContext.Ingredients)
        {
        }

        public IEnumerable<IngredientEntity> GetIngredientInDish(int dishId)
        {
            var result = _dbContext
                .Set<IngredientEntity>()
                .Where(ingradient => ingradient.DishEntityId == dishId)
                .ToList();
            return result;
        }
    }
}
