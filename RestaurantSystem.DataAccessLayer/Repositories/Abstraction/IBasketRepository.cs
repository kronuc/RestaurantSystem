using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Abstraction
{
    public interface IBasketRepository : IRepository<BasketEntity, int>
    {
        public BasketEntity GetBasketByUserName(string userName);
    }
}
