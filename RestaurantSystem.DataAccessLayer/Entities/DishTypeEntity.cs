using RestaurantSystem.DataAccessLayer.Entities;
using System;

namespace RestaurantSystem.DataModel
{
    public class DishTypeEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
