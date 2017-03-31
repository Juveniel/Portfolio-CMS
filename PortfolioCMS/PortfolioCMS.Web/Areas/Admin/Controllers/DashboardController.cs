using System.Web.Mvc;

namespace PortfolioCMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]    
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}