using RestaurantSystem.DataAccessLayer.Repositories.Abstraction;
using RestaurantSystem.DataAccessLayer.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.UnitOfWork.Realisation.EFRealisation
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RestorauntDbContext _dbContext;

        public EFUnitOfWork(RestorauntDbContext dbContext, IDishInBasketRepository dishInBasketRepository, IBasketRepository basketRepository, IDishRepository dishRepository, IDishTypeRepository dishTypeRepository, IIngradientRepository ingradientRepository)
        {
            _dbContext = dbContext;
            BasketRepository = basketRepository;
            DishInBasketRepository = dishInBasketRepository;
            DishRepository = dishRepository;
            DishTypeRepository = dishTypeRepository;
            IngradientRepository = ingradientRepository;
        }

        public IBasketRepository BasketRepository { get ; set ; }
        public IDishRepository DishRepository { get; set; }
        public IDishTypeRepository DishTypeRepository { get; set; }
        public IIngradientRepository IngradientRepository { get; set; }
        public IDishInBasketRepository DishInBasketRepository { get; set; }

        ~EFUnitOfWork()
        {
            _dbContext.Dispose();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
