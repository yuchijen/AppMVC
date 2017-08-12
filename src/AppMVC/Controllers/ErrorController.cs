using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC.Controllers
{
    //[HandleError(View = "DivideError", ExceptionType = typeof(DivideByZeroException))]
    //[HandleError(View = "NotFiniteError", ExceptionType = typeof(NotFiniteNumberException))]

    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            Exception e = new Exception("Cannot find this resource");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}