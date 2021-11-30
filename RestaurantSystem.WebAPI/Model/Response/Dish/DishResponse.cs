using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.DataModel;

namespace RestaurantSystem.WebAPI.Model.Response.Dish
{
    public class DishResponse
    {
        public Dish<int> Dish { get; set; }
    }
}
