using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentAPI_Prj.Models;

namespace FluentAPI_Prj.Controllers
{
    public class EDController : Controller
    {
        EDContext edContext = new EDContext();
        // GET: ED
        public ActionResult Index()
        {
            return View(edContext.Employees.ToList());
        }

        //create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            edContext.Employees.Add(e);
            edContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}