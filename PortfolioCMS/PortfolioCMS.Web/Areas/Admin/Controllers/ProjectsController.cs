using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioCMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProjectsController : Controller
    {
        // GET: Admin/Projects
        public ActionResult Index()
        {
            return View();
        }
    }
}