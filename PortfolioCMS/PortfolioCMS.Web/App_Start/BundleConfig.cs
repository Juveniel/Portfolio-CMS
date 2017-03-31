using System.Web;
using System.Web.Optimization;

namespace PortfolioCMS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.easing.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                        "~/Scripts/Views/layout.main.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(  
                        "~/Scripts/External/revslider/js/jquery.themepunch.tools.min.js",
                        "~/Scripts/External/revslider/js/jquery.themepunch.revolution.min.js",                                                               
                        "~/Scripts/External/particles/particles.min.js",
                        "~/Scripts/External/isotope/isotope.pkgd.min.js",
                        "~/Scripts/Views/home.main.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                        "~/Scripts/Admin/jquery-3.1.0.min.js",         
                        "~/Scripts/Admin/material.min.js",         
                        "~/Scripts/Admin/material-dashboard.min.js",         
                        "~/Scripts/Views/admin.main.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Fonts.css",
                      "~/Content/External/IonicIcons/ionicons.min.css",
                      "~/Content/External/FontAwesome/font-awesome.css",
                      "~/Content/External/Bootstrap/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(                  
                      "~/Scripts/External/revslider/css/settings.css",
                      "~/Scripts/External/revslider/css/captions-original.css",    
                      "~/Content/Home/slider.css",
                      "~/Content/Home/about.css",
                      "~/Content/Home/work.css",
                      "~/Content/Home/portfolio.css",
                      "~/Content/Home/contact.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                      "~/Content/External/FontAwesome/font-awesome.css",              
                      "~/Content/Admin/bootstrap.min.css",
                      "~/Content/Admin/material-dashboard.css",              
                      "~/Content/Admin/admin.main.css"));
        }
    }
}
