using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace PortfolioCMS.Web.App_Start.NinjectBindings
{
    public class ModelBindings : NinjectModule
    {
        public const string Models = "PortfolioCMS.Business.Models";

        public override void Load()
        {
            this.Bind(x => x.From(Models).SelectAllClasses().BindDefaultInterface());
        }
    }
}