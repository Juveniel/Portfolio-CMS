using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortfolioCMS.Web.Startup))]
namespace PortfolioCMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
