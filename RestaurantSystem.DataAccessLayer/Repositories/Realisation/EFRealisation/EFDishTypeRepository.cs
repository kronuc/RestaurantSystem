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
    public class EFDishTypeRepository : EFGenericRepository<DishTypeEntity, int>, IDishTypeRepository
    {
        public EFDishTypeRepository(RestorauntDbContext dbContext) : base(dbContext, dbContext.DishType)
        {
        }

        public IEnumerable<DishTypeEntity> GetDishTypeByName(string name)
        {
            var result = _dbContext
                .Set<DishTypeEntity>()
                .Where(item => item.Name.Contains(name))
                .ToList();
            return result;
        }
    }
}
