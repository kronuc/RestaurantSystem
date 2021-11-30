using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataAccessLayer.UnitOfWork.Abstraction;
using RestaurantSystem.DataModel;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Implementation
{
    public class BasketService : IBasketService<int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddDishToBasket(int dish, int basketId)
        {
            var newDishInBasket = new DishInBasketEntity()
            {
                DishEntityId = dish,
                BasketEntityId = basketId
            };
            if (_unitOfWork.DishRepository.GetById(dish) != null || _unitOfWork.BasketRepository.GetById(basketId) != null)
            {
                _unitOfWork
                    .DishInBasketRepository
                    .Create(newDishInBasket);
                _unitOfWork.Save();
            }
        }

        public Basket<int> CreateBasket(string userName)
        {
            var result = new Basket<int>()
            { 
                UserName = userName 
            };
            var existingBasket = _unitOfWork
                .BasketRepository
                .GetBasketByUserName(userName);
            if (existingBasket == null)
            {
                _unitOfWork.BasketRepository.Create(result.ToDbntity());
                _unitOfWork.Save();
                result = _unitOfWork.BasketRepository.GetBasketByUserName(result.UserName).ToModelEntity();
            }
            else
            {
                result = existingBasket.ToModelEntity();
            }
            return result;
        }

        public Basket<int> GetBasketById(int basketId)
        {
            var result = _unitOfWork
                .BasketRepository
                .GetById(basketId)
                .ToModelEntity();
            return result;
        }

        public IEnumerable<Dish<int>> GetDishesInBasket(int basket)
        {
            var result = _unitOfWork
                .DishRepository
                .GetDishEntitiesInBasket(basket)
                .Select(dish => dish.ToModelEntity());
            return result;
        }

        public void MakeOrder(Basket<int> basket)
        {
        }

        public void RemoveDishFromBasket(int basketId, int dishId)
        {

            _unitOfWork.DishInBasketRepository.RemooveDishFromBasket(basketId, dishId);
            _unitOfWork.Save();
        }

        public void MakeOrder(int basket)
        { }
    }
}
