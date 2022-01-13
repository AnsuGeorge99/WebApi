using ModelLayer;
using MvcLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLayer.Controllers
{
    public class HomeController : Controller
    {
        List<Employee> employeelist;
        public ActionResult Index()
        {
            employeelist = WebAPi.GetEmployee();
            return View(employeelist);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee emp = WebAPi.GetEmployee(id);       
            return View(emp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            bool check = WebAPi.CreateEmployee(emp);
            if (check)
            {
                return RedirectToAction("/");
            }
            return View("success");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = WebAPi.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee em)
        {
            bool check = WebAPi.EditEmployee(em);
            if (check)
            {
                return RedirectToAction("/");
            }
            return View("success");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            bool check = WebAPi.Delete(id);
            if(check)
            {
                return RedirectToAction("/");
            }
            return View("success");
        }

        
    }
}
