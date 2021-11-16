using System;

namespace RestaurantSystem.DataModel
{
    public class DishType<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
