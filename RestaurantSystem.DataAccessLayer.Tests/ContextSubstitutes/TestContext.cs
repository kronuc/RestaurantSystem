using NSubstitute;
using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Tests.ContextSubstitutes
{
    public class TestContext : RestorauntDbContext
    {
        public ISaveChangesHandler SaveChangesHandlerHandler;

        public TestContext()
        {
            SaveChangesHandlerHandler = Substitute.For<ISaveChangesHandler>();
            BasketsSubstitute = new TestDbSet<BasketEntity>();
            IngredientsSubstitute = new TestDbSet<IngredientEntity>();
            DishesSubstitute = new TestDbSet<DishEntity>();
            DishTypeSubstitute = new TestDbSet<DishTypeEntity>();
            DishInBasketsSubstitute = new TestDbSet<DishInBasketEntity>();
        }

        public TestDbSet<BasketEntity> BasketsSubstitute { get; set; }
        public TestDbSet<IngredientEntity> IngredientsSubstitute { get; set; }
        public TestDbSet<DishEntity> DishesSubstitute { get; set; }
        public TestDbSet<DishTypeEntity> DishTypeSubstitute { get; set; }
        public TestDbSet<DishInBasketEntity> DishInBasketsSubstitute { get; set; }

        public sealed override DbSet<BasketEntity> Baskets
        {
            get => BasketsSubstitute;
            set { }
        }
        public sealed override DbSet<IngredientEntity> Ingredients
        {
            get => IngredientsSubstitute;
            set { }
        }
        public sealed override DbSet<DishEntity> Dishes
        {
            get => DishesSubstitute;
            set { }
        }
        public sealed override DbSet<DishTypeEntity> DishType
        {
            get => DishTypeSubstitute;
            set { }
        }
        public sealed override DbSet<DishInBasketEntity> DishInBaskets
        {
            get => DishInBasketsSubstitute;
            set { }
        }
        
        public override int SaveChanges()
        {
            return SaveChangesHandlerHandler.SaveChanges();
        }
    }

    public interface ISaveChangesHandler
    {
        public int SaveChanges();
    }
}
