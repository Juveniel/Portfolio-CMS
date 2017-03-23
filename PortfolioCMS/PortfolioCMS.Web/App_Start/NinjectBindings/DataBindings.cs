using Ninject.Modules;
using PortfolioCMS.Business.Data;
using PortfolioCMS.Business.Data.Contracts;
using PortfolioCMS.Business.Data.Repositories;
using PortfolioCMS.Business.Data.UnitOfWork;

namespace PortfolioCMS.Web.App_Start.NinjectBindings
{
    public class DataBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>));
            this.Bind<IPortfolioCmsDbContext>().To<PortfolioCmsDbContext>().InSingletonScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}