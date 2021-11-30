using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.Services.Abstractions;
using RestaurantSystem.WebAPI.Model.Commands.DishType;
using RestaurantSystem.WebAPI.Model.Response.DishType;

namespace RestaurantSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishTypeController : ControllerBase
    {
        private readonly IDishTypeService<int> _dishTypeService;

        public DishTypeController(IDishTypeService<int> dishTypeService)
        {
            _dishTypeService = dishTypeService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(DishTypeResponse), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] GetDishTypeCommand command)
        {
            var result = _dishTypeService.GetDishTypeById(command.DishTypeId);
            return Ok(new DishTypeResponse() { DishType = result });
        }

        [HttpGet]
        [Route("/all")]
        [ProducesResponseType(typeof(DishTypesResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllDishTypesCommand command)
        {
            var result = _dishTypeService.GetAllDishTypes().ToList();
            return Ok(new DishTypesResponse() { DishTypes = result });
        }

        [HttpGet]
        [Route("/ByName")]
        [ProducesResponseType(typeof(DishTypesResponse), StatusCodes.Status200OK)]
        public IActionResult GetDihsByType([FromQuery] GetDishTypesByNameCommand command)
        {
            var result = _dishTypeService.GetDishTypesByName(command.Name).ToList();
            return Ok(new DishTypesResponse() { DishTypes = result });
        }
    }
}
