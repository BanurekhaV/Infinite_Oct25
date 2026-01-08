using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Custom_ModelBinding_Prj.Models;
using Custom_ModelBinding_Prj.CustomBindings;

namespace Custom_ModelBinding_Prj.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(CustomBinder))]CustomModel cm)
        {
            ViewBag.ctitle= cm.Title;
            ViewBag.dt=cm.Date;
            return View(cm);
        }

        //bundling scripts
        public ActionResult Bundling_Minify()
        { 
            return View();
        }

    }
}