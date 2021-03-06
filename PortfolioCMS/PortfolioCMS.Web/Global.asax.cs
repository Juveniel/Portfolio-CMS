﻿using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PortfolioCMS.Web.App_Start;
using PortfolioCMS.Web.App_Start.AutoMapper;

namespace PortfolioCMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Config();
            ViewEnginesConfig.RegisterViewEngines();
            AutoMapperConfig.Config(Assembly.GetExecutingAssembly());
            AreaRegistration.RegisterAllAreas();        
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
