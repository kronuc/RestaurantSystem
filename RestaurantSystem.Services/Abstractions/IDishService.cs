using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Abstractions
{
    public interface IDishService<TKey>
    {
        public IEnumerable<Dish<TKey>> FindDishByType(TKey type);
        public Dish<TKey> GetDishById(TKey Id);
    }
}
