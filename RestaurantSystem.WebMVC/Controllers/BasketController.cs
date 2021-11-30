using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantSystem.Services.Abstractions;

namespace RestaurantSystem.WebMVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService<int> _basketService;

        public BasketController(IBasketService<int> basketService)
        {
            _basketService = basketService;
        }

        [Route("/Basket")]
        public IActionResult BasketItems()
        {
            var items = _basketService.GetDishesInBasket(1);
            return View("DishInBasket", items);
        }

        [Route("/Basket/Remove/{id}")]
        public IActionResult RemoveItemFormBasket(int id)
        {
            _basketService.RemoveDishFromBasket(1, id);
            var items = _basketService.GetDishesInBasket(1);
            return View("DishInBasket", items);
        }
    }
}
