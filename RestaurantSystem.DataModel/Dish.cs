using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class Dish<TKey>
    {
        public TKey Id { get; set; }
        public TKey TypeId { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
    }
}
