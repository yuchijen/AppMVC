using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC.Controllers
{
    public class NgPageController : Controller
    {
        // GET: NgPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

    }
}