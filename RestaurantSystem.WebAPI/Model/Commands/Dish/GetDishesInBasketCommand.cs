using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.Dish
{
    public class GetDishesInBasketCommand
    {
        [Required]
        public int BasketId { get; set; }
    }
}
