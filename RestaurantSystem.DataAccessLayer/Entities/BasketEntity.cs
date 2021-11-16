using RestaurantSystem.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class BasketEntity : BaseEntity<int>
    {
        public string UserName { get; set; }
    }
}
