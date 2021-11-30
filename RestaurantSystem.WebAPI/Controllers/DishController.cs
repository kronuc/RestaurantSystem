using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.WebAPI.Model.Commands.Dish;
using RestaurantSystem.WebAPI.Model.Response.Dish;

namespace RestaurantSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : Controller
    {
        private readonly IDishService<int> _dishService;
        private readonly IBasketService<int> _basketService;

        public DishController(IDishService<int> dishService, IBasketService<int> basketService)
        {
            _dishService = dishService;
            _basketService = basketService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(DishResponse), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] GetDishCommand command)
        {
            var result = _dishService.GetDishById(command.DishId);
            return Ok(new DishResponse() { Dish = result });
        }

        [HttpGet]
        [Route("/all")]
        [ProducesResponseType(typeof(DishesResponse), StatusCodes.Status200OK)]
        public IActionResult GetByType([FromQuery] GetAllDishesByTypeCommand command)
        {
            var result = _dishService.FindDishByType(command.DishTypeId).ToList();
            return Ok(new DishesResponse() { Dishes = result });
        }

        [HttpGet]
        [Route("/InBasket")]
        [ProducesResponseType(typeof(DishesResponse), StatusCodes.Status200OK)]
        public IActionResult GetDishInBasket([FromQuery] GetDishesInBasketCommand command)
        {
            var result = _basketService.GetDishesInBasket(command.BasketId).ToList();
            return Ok(new DishesResponse() { Dishes = result });
        }
        
        [HttpPut]
        [Route("/AddToBasket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDishToBasket([FromQuery] AddDishToBasketCommand command)
        {
            _basketService.AddDishToBasket(command.DishId, command.BasketId);
            return Ok();
        }

        [HttpDelete]
        [Route("/DeleteFromBasket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveDishFromBasket([FromQuery] RemoveDishFromBasket command)
        {
            _basketService.RemoveDishFromBasket(command.BasketId, command.DishId);
            return Ok();
        }
    }
}
