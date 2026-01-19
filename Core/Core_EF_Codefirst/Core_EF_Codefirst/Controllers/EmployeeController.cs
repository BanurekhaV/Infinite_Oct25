using Microsoft.AspNetCore.Mvc;
using Core_EF_Codefirst.Models;
using Core_EF_Codefirst.Services;

namespace Core_EF_Codefirst.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;

        public EmployeeController(IEmployeeRepository eRepo)
        {
            _empRepo = eRepo;
        }
        public IActionResult Index()
        {
            var emp = _empRepo.GetAllEmployees();
            return View(emp);
        }

        public IActionResult GetEmpById(int id)
        {
            Employee e = _empRepo.GetEmployeeById(id);
            return View(e);
        }

        public ViewResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            _empRepo.AddEmployee(emp);
            return RedirectToAction("Index");   
        }

        public IActionResult DeleteEmployee(int id)
        {
            _empRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee e = _empRepo.GetEmployeeById(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            _empRepo.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }
    }
}
