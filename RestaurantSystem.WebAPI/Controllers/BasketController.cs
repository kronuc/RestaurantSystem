using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.WebAPI.Model.Commands.Basket;
using RestaurantSystem.WebAPI.Model.Response.Basket;

namespace RestaurantSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService<int> _basketService;
        
        public BasketController(IBasketService<int> basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketResponse), StatusCodes.Status200OK)]
        public IActionResult GetBasketById([FromQuery] GetBasketCommand command)
        {
            var result = _basketService.GetBasketById(command.BasketId);
            return Ok(new BasketResponse() {Basket = result});
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketResponse), StatusCodes.Status200OK)]
        public IActionResult AddBasket([FromBody] AddBasketCommand command)
        {
            var result = _basketService.CreateBasket(command.UserName);
            return Ok(new BasketResponse() { Basket = result });
        }
    }
}
