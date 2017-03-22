using System.Web.Mvc;

namespace PortfolioCMS.Web.App_Start
{
    public class ViewEnginesConfig
    {
        public static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}