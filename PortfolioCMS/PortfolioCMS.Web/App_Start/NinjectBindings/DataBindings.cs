using System.Data.Entity;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
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
            this.Bind<DbContext>().To<PortfolioCmsDbContext>().InRequestScope();
            this.Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>)).InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}