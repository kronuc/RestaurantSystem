using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.Services.Abstractions;

namespace RestaurantSystem.WebMVC.Controllers
{
    public class DishesTypeController : Controller
    {
        private readonly IDishTypeService<int> _dishTypeService;

        public DishesTypeController(IDishTypeService<int> dishTypeService)
        {
            _dishTypeService = dishTypeService;
        }

        [Route("/Dishes")]
        public IActionResult Dishes()
        {
            return View("DishesMenu");
        }

        [Route("/Dishes/All")]
        public IActionResult ShowAllDishTypes()
        {
            var dishTypes = _dishTypeService.GetAllDishTypes();
            return View("AllDishes", dishTypes);
        }
        
        [Route("Dishes/GetByName")]
        public IActionResult ShowDishesWithName(string name)
        {
            var dishTypes = _dishTypeService.GetDishTypesByName(name);
            return View("GetDishByName", dishTypes);
        }
    }
}
