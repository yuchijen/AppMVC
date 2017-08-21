using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppMVC.ViewModels;
using AppMVC.Filter;

namespace AppMVC.Controllers
{

    public class EmployeeController : Controller
    {
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            employeeListViewModel.FooterData = new FooterViewModel()
            {
                CompanyName = "StepByStepSchools",
                Year = DateTime.Now.Year.ToString()
            };

            employeeListViewModel.UserName = User.Identity.Name; //New Line
            return View("CreateEmployee", employeeListViewModel);
        }

        public ActionResult ReceiveTempData()
        {
            string userName = "";
            int userAge = 0;
            if (TempData.ContainsKey("TempName"))
                userName = TempData["TempName"].ToString();

            if (TempData.ContainsKey("TempVal"))
                userAge = int.Parse(TempData["TempVal"].ToString());
            ViewBag.Message = userName + userAge.ToString();

            return View();
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        var ebl = new EmployeeBusinessLayer();
                        ebl.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;

                        //vm.FooterData = new FooterViewModel();
                        //vm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
                        //vm.FooterData.Year = DateTime.Now.Year.ToString();
                        //vm.UserName = User.Identity.Name; //New Line

                        if (e.Salary!=0)
                            vm.Salary = e.Salary.ToString();
                        else
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HeaderFooterFilter]
        public ActionResult Index()
        {

            var employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name; //New Line

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            IQueryable<Employee> employees = empBal.GetEmployees().Where(x=>x.EmployeeId >1 );
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

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

            ////attach footer info here
            //employeeListViewModel.FooterData = new FooterViewModel();
            //employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            //employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();

            return View("Index", employeeListViewModel);
            


            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 15000)
            //    vmEmp.SalaryColor = "green";
            //else
            //    vmEmp.SalaryColor = "yellow";


            //ViewBag.Employee = emp;
            //ViewData["Employee"] = emp;

            //return View("MyView",employees);
        }

        [ChildActionOnly]
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
        // GET: Test        
        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

    }
}