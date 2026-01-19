using Core_DI_Prj.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_DI_Prj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository repo)  //DI in constructor
        {
            _studentRepository = repo;
        }
        public JsonResult Index([FromServices]IStudentRepository srepo)   //DI in method
        {
            List<Student> ? allstudents = srepo.GetAll();
            return Json(allstudents);
        }

        public JsonResult StudentDetails(int id)
        {
            // StudentRepository sr = new StudentRepository();
           // Student? student = sr.Get(id);
            Student? student = _studentRepository?.Get(id);
            
            return Json(student);
        }
           
    }
}
