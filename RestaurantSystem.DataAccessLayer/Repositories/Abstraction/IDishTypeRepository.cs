using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Abstraction
{
    public interface IDishTypeRepository : IRepository<DishTypeEntity, int>
    {
        public IEnumerable<DishTypeEntity> GetDishTypeByName(string name);
    }
}
