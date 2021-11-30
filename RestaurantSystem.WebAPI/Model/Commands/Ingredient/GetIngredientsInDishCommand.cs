using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.Ingredient
{
    public class GetIngredientsInDishCommand
    {

        [Required]
        public int DishId { get; set; }
    }
}
