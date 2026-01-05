using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;

namespace MVC_DatabaseFirst.Controllers
{
    public class NavigationController : Controller
    {
        NorthwindEntities db= new NorthwindEntities();
        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        //1. Fetching data from multiple tables/objects using navigation property
        public ActionResult MultipleData()
        {
            return View(db.Orders.ToList());
        }
    }
}