using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class Ingredient<Tkey>
    {
        public Tkey Id { get; set; }
        public Tkey DishId { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public float Weight { get; set; }
    }
}
