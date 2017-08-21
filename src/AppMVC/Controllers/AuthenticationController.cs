using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppMVC.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public string RouteTest(int? testData)
        {
            //ViewBag.TestData = testData;
            string temp = testData.HasValue ? testData.ToString() : "";
            return "route test here , data: " + temp;
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();

                //New Code Start
                UserStatus status = bal.GetUserValidity(u);
                bool IsAdmin = false;
                
                if (status == UserStatus.AuthenticatedAdmin)
                    IsAdmin = true;
                else if (status == UserStatus.AuthentucatedUser)
                    IsAdmin = false;
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Main", new { area = "SPA" });
                //New Code End
            }
            else
                return View("Login");
            
        }

        
    }
}