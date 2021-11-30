﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSystem.WebAPI.Model.Commands.Ingredient
{
    public class GetIngredientCommand
    {
        [Required]
        public int IngredientId { get; set; }
    }
}
