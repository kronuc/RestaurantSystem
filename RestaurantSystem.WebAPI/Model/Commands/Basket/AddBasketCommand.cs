using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.Basket
{
    public class AddBasketCommand
    {
        [Required]
        public string UserName { get; set; }
    }
}
