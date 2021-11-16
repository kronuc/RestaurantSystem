using RestaurantSystem.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class DishEntity : BaseEntity<int>
    {
        public int DishTypeEntityId { get; set; }
        public DishTypeEntity DishTypeEntity { get; set; }

        public float Weight { get; set; }
        public float Price { get; set; }
    }
}
