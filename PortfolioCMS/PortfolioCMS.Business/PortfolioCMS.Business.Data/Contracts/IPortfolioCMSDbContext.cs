using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PortfolioCMS.Business.Data.Contracts
{
    public interface IPortfolioCmsDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
    
}
