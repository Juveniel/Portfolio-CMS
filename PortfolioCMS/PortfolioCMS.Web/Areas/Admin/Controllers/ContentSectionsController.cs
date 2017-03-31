using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioCMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ContentSectionsController : Controller
    {
        // GET: Admin/ContentSections
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Trips/Create
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }
    }
}