using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters_Prj.Models;

namespace Filters_Prj.Controllers
{
    //[AllowAnonymous]

    // [HandleError(ExceptionType = typeof(DivideByZeroException), View = "DivideByZero")]
    // [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReference")]
    // [HandleError]

   // [LogCustomException]
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            throw new Exception("Something Went Wrong..");
            //  return View();
        }

        //

        public ActionResult TestMethod1()
        {
            throw new NullReferenceException();
        }

       
        public ActionResult TestMethod2()
        {
            throw new DivideByZeroException();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}