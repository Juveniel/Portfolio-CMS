using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace PortfolioCMS.Web.App_Start.NinjectBindings
{
    public class ServiceBindings : NinjectModule
    {
        public const string Services = "PortfolioCMS.Business.Services";

        public override void Load()
        {
            this.Bind(x => x.From(Services).SelectAllClasses().BindDefaultInterface().Configure(b => b.InRequestScope()));
        }
    }
}