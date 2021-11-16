using RestaurantSystem.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class IngredientEntity : BaseEntity<int>
    {
        public int DishEntityId { get; set; }
        public DishEntity DishEntity { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public float Weight { get; set; }
    }
}
