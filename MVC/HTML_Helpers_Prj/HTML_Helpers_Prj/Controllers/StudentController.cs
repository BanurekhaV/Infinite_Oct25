using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTML_Helpers_Prj.Models;

namespace HTML_Helpers_Prj.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //1. stronglytyped helper
        public ActionResult Strongly_Typed_Helper()
        {
            return View();
        }

        //2. templated helper individual
        public ActionResult TemplatedHelper_ind()
        {
            return View();
        }

        //3. templated helper for the entire model (editor template)
        public ActionResult TemplateForModel()
        {
            return View();
        }

        //4. Display template
        public ActionResult StudentDisplay()
        {
            Student student = new Student()
            {
                RNO = 10,
                Name = "Rahul",
                Address = "Chennai",
            };
            ViewData["stddata"]= student;
            return View(student); 
        }
        //5. standard helper
        public ActionResult StandardHelper()
        {
            return View();
        }
    }
}