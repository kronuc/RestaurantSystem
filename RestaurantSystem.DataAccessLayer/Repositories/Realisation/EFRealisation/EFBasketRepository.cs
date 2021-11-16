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
    public class EFBasketRepository : EFGenericRepository<BasketEntity, int>, IBasketRepository
    {
        public EFBasketRepository(RestorauntDbContext dbContext) : base(dbContext, dbContext.Baskets)
        {

        }

        public BasketEntity GetBasketByUserName(string userName)
        {
            var result = _dbContext
                .Baskets
                .FirstOrDefault(basket => basket.UserName == userName);
            return result;
        }
    }
}
