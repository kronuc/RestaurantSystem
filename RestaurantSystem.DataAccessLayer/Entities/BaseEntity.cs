using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Entities
{
    public abstract class BaseEntity<KId>
    {
        public KId Id { get; set; }
    }
}
