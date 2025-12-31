using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers
{
    public class HRController : Controller
    {
        // GET: HR
        public ActionResult Index()
        {
            return View();
        }

        //1. binding a model object to a view
        public ActionResult DisplayEmployee()
        {
            Employee employee = new Employee() {ID=1, Name="Rahul",Age=21 };
            return View(employee);  //passing a model object of type Employee
        }
    }
}