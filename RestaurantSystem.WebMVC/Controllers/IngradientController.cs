using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.Services.Abstractions;

namespace RestaurantSystem.WebMVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService<int> _ingredientService;

        public IngredientController(IIngredientService<int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [Route("/Ingredient/{dishId}")]
        public IActionResult GetIngredientInDish(int dishId)
        {
            var ingredient = _ingredientService.GetAllIngredientInDish(dishId);
            return View("Ingradient", ingredient);
        }
    }
}
