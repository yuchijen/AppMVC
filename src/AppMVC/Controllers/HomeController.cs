using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult TestTempData()
        {
            TempData["TempName"] = "Test temp data";
            TempData["TempVal"] = 30;

            ViewBag.Message = "Test temp data 30";
            return RedirectToAction("ReceiveTempData", "Employee");
        }

        public ActionResult About()
        {
         
            string userName="";
            int userAge=0;
            if (TempData.ContainsKey("TempName"))
                userName = TempData["TempName"].ToString();

            if (TempData.ContainsKey("TempVal"))
                userAge = int.Parse(TempData["TempVal"].ToString());
            ViewBag.Message = userName + userAge.ToString();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";            
            return View();
        }

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }
    }
}