using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppMVC.ViewModels.SPA;
using OldViewModel = AppMVC.ViewModels;
using AppMVC.Models;
using AppMVC.Filter;

namespace AppMVC.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        // GET: SPA/Main        
        public ActionResult Index()
        {
            MainViewModel v = new MainViewModel();
            v.UserName = User.Identity.Name;
            v.FooterData = new OldViewModel.FooterViewModel();
            v.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            v.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", v);
        }

        [AdminFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel cevm = new CreateEmployeeViewModel();
            return PartialView("CreateEmployee", cevm);
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        public ActionResult SaveEmployee(Employee emp)
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            empBal.SaveEmployee(emp);

            EmployeeViewModel empViewModel = new EmployeeViewModel();
            empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
            empViewModel.Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
                empViewModel.SalaryColor = "yellow";            
            else
                empViewModel.SalaryColor = "green";
            
            return Json(empViewModel);
        }

        public ActionResult EmployeeList()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            IQueryable<Employee> employees = empBal.GetEmployees();

            List <EmployeeViewModel > empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            return View("EmployeeList", employeeListViewModel);
        }

    }
}