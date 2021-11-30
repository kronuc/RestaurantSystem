using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.DishType
{
    public class GetDishTypesByNameCommand
    {
        [Required]
        public string Name { get; set; }
    }
}
