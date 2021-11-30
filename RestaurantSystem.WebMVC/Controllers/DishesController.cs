using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantSystem.Services.Abstractions;

namespace RestaurantSystem.WebMVC.Controllers
{
    public class DishesController : Controller
    {
        private readonly IDishService<int> _dishService;
        private readonly IBasketService<int> _basketService;

        public DishesController(IDishService<int> dishService, IBasketService<int> basketService)
        {
            _dishService = dishService;
            _basketService = basketService;
        }

        [Route("/Dishes/{typeId}")]
        public IActionResult DishesWithType(int typeId)
        {
            var items = _dishService.FindDishByType(typeId);
            return View("DishesWithType", items);
        }

        [Route("/Dishes/{dishId}/AddToBasket")]
        public IActionResult AddToBasket(int typeId,int dishId)
        {
            _basketService.AddDishToBasket(dishId, 1);
            var items = _dishService.FindDishByType(typeId);
            return View("DishesWithType", items);
        }
    }
}
