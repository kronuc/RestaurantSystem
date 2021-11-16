using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer
{
    public class RestorauntDbContext : DbContext
    {
        #region ctrs

        public RestorauntDbContext() : base("RestaurantSystemDb")
        {
            Database.CreateIfNotExists();
        }

        #endregion ctrs

        #region members

        public virtual DbSet<BasketEntity> Baskets { get; set; }
        public virtual DbSet<IngredientEntity> Ingredients { get; set; }
        public virtual DbSet<DishEntity> Dishes { get; set; }
        public virtual DbSet<DishTypeEntity> DishType { get; set; }
        public virtual DbSet<DishInBasketEntity> DishInBaskets { get; set; }

        #endregion members
    }
}
