using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Entities
{
    public class DishInBasketEntity : BaseEntity<int>
    {
        public int DishEntityId { get; set; }
        public DishEntity DishEntity { get; set; }
        public int BasketEntityId { get; set; }
        public BasketEntity BasketEntity { get; set; }

    }
}
