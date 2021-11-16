using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Abstractions
{
    public interface IBasketService<T>
    {
        public Basket<T> CreateBasket(string UserName);
        public IEnumerable<Dish<T>> GetDishesInBasket(Basket<T> basket);
        public Basket<int> GetBasketById(T basketId);
        public void AddDishToBasket(Dish<T> dish, T basketId);
        public void RemoveDishFromBasket(T basketId, T dishId);
        public void MakeOrder(Basket<int> basket);
    }
}
