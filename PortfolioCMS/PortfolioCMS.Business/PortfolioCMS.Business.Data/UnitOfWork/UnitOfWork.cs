using Bytes2you.Validation;
using PortfolioCMS.Business.Data.Contracts;

namespace PortfolioCMS.Business.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPortfolioCmsDbContext context;

        public UnitOfWork(IPortfolioCmsDbContext context)
        {
            Guard.WhenArgument(context, "Db context is null!").IsNull().Throw();

            this.context = context;
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
