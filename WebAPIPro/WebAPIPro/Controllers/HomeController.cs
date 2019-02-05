using BusinessLayer.Repositories;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIPro.Controllers
{
    public class HomeController : Controller
    {
        readonly EmployeeDetails empDetails;
        public HomeController()
        {
            empDetails = new EmployeeDetails();
        }
        public ActionResult Index()
        {
            var list = empDetails.GetAllEmployees();

            ViewBag.Title = "Home Page";

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            ViewBag.Title = "Add New Employee";
            bool status = empDetails.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EmployeeByDepartment(EmployeeModel employee)
        {
            var list = empDetails.GetAllEmployees();

            ViewBag.Title = "Employee By Department";

            return View(list);
        }

    }
}
