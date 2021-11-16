using AutoBogus;
using FluentAssertions;
using NSubstitute;
using RestaurantSystem.DataAccessLayer.Entities;
using RestaurantSystem.DataAccessLayer.Repositories.Realisation.EFRealisation;
using RestaurantSystem.DataAccessLayer.Tests.ContextSubstitutes;
using RestaurantSystem.DataModel;
using System;
using System.Data.Entity;
using Xunit;

namespace RestaurantSystem.DataAccessLayer.Tests
{
    public class EFBasketRepositoryTests
    {
        private readonly TestContext _dbContext;
        private readonly EFBasketRepository _target;

        public EFBasketRepositoryTests()
        {
            _dbContext = new TestContext();
            _target = new EFBasketRepository(_dbContext);
        }

        [Fact]
        public void Create_BasketEntity_DbContextCall()
        {
            // arrange
            var basket = AutoFaker.Generate<BasketEntity>();

            _dbContext
                .BasketsSubstitute
                .Add(basket)
                .Returns(basket);
            
            // aciton
            _target.Create(basket);

            // assert
            _dbContext.BasketsSubstitute.Handler.Received().Add(Arg.Any<BasketEntity>());
        }
    }
}
