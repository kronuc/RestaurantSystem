using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataModel
{
    public class Basket<TKey>
    {
        public TKey Id { get; set; }
        public string UserName { get; set; }
    }
}
