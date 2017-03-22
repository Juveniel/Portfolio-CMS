using System;

namespace PortfolioCMS.Business.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
