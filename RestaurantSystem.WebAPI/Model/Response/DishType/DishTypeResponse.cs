using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.DataModel;

namespace RestaurantSystem.WebAPI.Model.Response.DishType
{
    public class DishTypeResponse
    {
        public DishType<int> DishType { get; set; }
    }
}
