using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Repositories.Abstraction
{
    public interface IIngradientRepository : IRepository<IngredientEntity, int>
    {
        public IEnumerable<IngredientEntity> GetIngredientInDish(int dishId);
    }
}
