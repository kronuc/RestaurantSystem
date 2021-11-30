using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.WebAPI.Model.Commands.Ingredient;
using RestaurantSystem.WebAPI.Model.Response.Ingredient;

namespace RestaurantSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService<int> _ingredientService;
        
        public IngredientController(IIngredientService<int> ingredientService)
        {
            _ingredientService = ingredientService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IngredientResponse), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] GetIngredientCommand command)
        {
            var result = _ingredientService.GetIngredientById(command.IngredientId);
            return Ok(new IngredientResponse() { Ingredient = result });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IngredientsResponse), StatusCodes.Status200OK)]
        [Route("/inDish")]
        public IActionResult GetById([FromQuery] GetIngredientsInDishCommand command)
        {
            var result = _ingredientService.GetAllIngredientInDish(command.DishId).ToList();
            return Ok(new IngredientsResponse() { Ingredients = result });
        }
    }
}
