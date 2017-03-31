using System;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioCMS.Business.Data.Contracts
{
    public interface IEFRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        IQueryable<T> All();

        T GetFirst(Expression<Func<T, bool>> filter);

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
