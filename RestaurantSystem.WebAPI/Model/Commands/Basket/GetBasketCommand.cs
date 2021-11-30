using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.Basket
{
    public class GetBasketCommand
    {
        [Required]
        public int BasketId { get; set; }
    }
}
