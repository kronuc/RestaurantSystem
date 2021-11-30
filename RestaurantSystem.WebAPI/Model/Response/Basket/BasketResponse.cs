using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSystem.DataModel;

namespace RestaurantSystem.WebAPI.Model.Response.Basket
{
    public class BasketResponse
    {
        public Basket<int> Basket { get; set; }
    }
}
