using RestaurantSystem.DataAccessLayer.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.UnitOfWork.Abstraction
{
    public interface IUnitOfWork
    {
        public IBasketRepository BasketRepository { get; set; }
        public IDishRepository DishRepository { get; set; }
        public IDishTypeRepository DishTypeRepository { get; set; }
        public IIngradientRepository IngradientRepository { get; set; }
        public IDishInBasketRepository DishInBasketRepository { get; set; }
        public void Save();
    }
}
