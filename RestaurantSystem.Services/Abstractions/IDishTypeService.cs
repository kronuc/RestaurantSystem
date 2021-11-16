using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Services.Abstractions
{
    public interface IDishTypeService<TKey>
    {
        public IEnumerable<DishType<TKey>> GetAllDishTypes();
        public IEnumerable<DishType<TKey>> GetDishTypesByName(string name);
        public DishType<TKey> GetDishTypeById(TKey id);
    }
}
