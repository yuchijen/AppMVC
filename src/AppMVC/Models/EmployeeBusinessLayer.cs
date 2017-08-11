using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppMVC.DataAccessLayer;
using System.Web.Mvc;

namespace AppMVC.Models
{

    public class EmployeeBusinessLayer
    {
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public IQueryable<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            

            return salesDal.Employees;

            //List<Employee>  employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.FirstName = "johnson";
            //emp.LastName = " fernandes";
            //emp.Salary = 14000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "michael";
            //emp.LastName = "jackson";
            //emp.Salary = 16000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "robert";
            //emp.LastName = " pattinson";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //return employees;
        }

        //mock validating login
        //public bool IsValidUser(UserDetails u)
        //{
        //    if (u.UserName == "Admin" && u.Password == "Admin")
        //        return true;
        //    else
        //        return false;
        //}

        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Sukesh" && u.Password == "Sukesh")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

    }
}