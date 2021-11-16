using NSubstitute;
using RestaurantSystem.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.DataAccessLayer.Tests.ContextSubstitutes
{
    public class TestDbSet<T> : DbSet<T> where T : BaseEntity<int>
    {
        public IDbSetActionsHandler<T> Handler;

        public TestDbSet() : base()
        {
            Handler = Substitute.For< IDbSetActionsHandler<T>>();
        }

        public override T Add(T entity)
        {
            return Handler.Add(entity);
        }
        
    }

    public interface IDbSetActionsHandler<T> where T : BaseEntity<int>
    {
        public T Add(T entity);
    }
}
