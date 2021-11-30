using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.DataModel;

namespace RestaurantSystem.WebAPI.Model.Response.Ingredient
{
    public class IngredientResponse
    {
        public Ingredient<int> Ingredient { get; set; }
    }
}
