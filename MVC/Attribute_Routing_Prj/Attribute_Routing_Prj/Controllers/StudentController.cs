using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attribute_Routing_Prj.Models;

namespace Attribute_Routing_Prj.Controllers
{
    [RoutePrefix("Trainees")]
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Preethi"},
            new Student{Id=2,Name="Vaibhavi"},
            new Student{Id=3,Name="Naresh"},
            new Student{Id=4,Name="Ram"},
            new Student{Id=5,Name="Sneha"},
        };
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route]
        public ActionResult GetAllStudents()
        {
            return View(students);
        }

        //2. get by id
        // [Route("{studentId:int:min(1):max(3)}")] // can be also written as below
        [Route("{studentId:int:range(1,3)}")]
        public ActionResult GetStudentDetails(int studentId)
        {
            Student student = students.FirstOrDefault(s => s.Id == studentId);
            ViewBag.data = "Student Id";
            return View(student);
        }

        //3. by name
        [HttpGet]
        [Route("{studentname:alpha:minlength(4)}")]
        public ActionResult GetStudentDetails(string studentname)
        {
            Student stddetails = students.FirstOrDefault(s => s.Name == studentname);
            ViewBag.data = "Student Name";
            return View(stddetails);
        }

        //get studentcourses
        [HttpGet]
        [Route("{studentId}/courses")]
        public ActionResult GetStudentCourses(int studentId)
        {
            List<string> Courselist;
            if (studentId == 1)
                Courselist = new List<string>() { "ASP.Net", "C#", "SQL" };
            else if (studentId == 2)
                Courselist = new List<string>() { "MVC", "ADO.Net", "C#" };
            else if (studentId == 3)
                Courselist = new List<string>() { "WebAPI", "C#", "Javascript" };
            else
                Courselist = new List<string>() { "Bootstrap", "JQuery", "React Js" };

            ViewBag.courses = Courselist;
            return View();
        }

        //populate the second object model trainer

      //  [Route("technical/trainers")]  //this works with the prefix followed by the route
        //~ is used to override a routeprefix
        [Route("~/Technical/trainers")]
       
        public ActionResult GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>()
            {
                new Trainer { Id = 100, Name = "Geetha" },
                new Trainer { Id = 101, Name = "Anand" },
                new Trainer { Id = 102, Name = "Jamuna" }
            };
            return View(trainers);
        }
    }
}