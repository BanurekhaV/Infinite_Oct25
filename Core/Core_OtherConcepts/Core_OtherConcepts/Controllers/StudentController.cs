using Core_OtherConcepts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_OtherConcepts.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> studentsList = new List<Student>()
        {
            new Student{Id = 1, Name= "Priya"},
             new Student{Id = 2, Name= "Anand"},
              new Student{Id = 3, Name= "Surya"},
        };


        //1. to understand tag helpers

        public ViewResult Index()
        {
            return View(studentsList);
        }
        //2. Std details
        public ViewResult StdDetails(int id)
        {
            var stddata = studentsList.FirstOrDefault(x => x.Id == id);
            return View(stddata);
        }

        //3. the below for attribute routing
        [Route("Student/All")]
        public List<Student> GetAllStudents()
        {
            return studentsList;
        }

        [Route("Student/{sid}/Details")]
        public Student GetStudentById(int sid)
        {
            Student? studentdetails = studentsList.FirstOrDefault(s => s.Id == sid);
            return studentdetails ?? new Student();
        }

        [Route("Student/{sid}/Courses")]
        public List<string>GetStudentCourses(int sid)
        {
            List<string>CourseList = new List<string>();
            if(sid ==1)
            {
                CourseList = new List<string> { "ASP.net Core", "C#.Net", "SQL" };
            }
              
            else if(sid == 2)
            {
                CourseList = new List<string> { "ASP.net CoreMVC", "ADO.Net", "SQL" };
            }
            else if(sid ==3)
            {
                CourseList = new List<string> { "ASP.net Core WebAPI", "ADO.Net", "EFCore" };
            }
            else
            {
                CourseList = new List<string> { "BootStarp", "Javascript", "HTML" };
            }
            return CourseList;
        }

            
    }
}
