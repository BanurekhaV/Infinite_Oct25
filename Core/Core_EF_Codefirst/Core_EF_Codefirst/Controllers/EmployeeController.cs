using Microsoft.AspNetCore.Mvc;
using Core_EF_Codefirst.Models;
using Core_EF_Codefirst.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Core_EF_Codefirst.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly Emp_DeptContext _empDeptContext;
            
        public EmployeeController(IEmployeeRepository eRepo, Emp_DeptContext Context)
        {
            _empRepo = eRepo;
            _empDeptContext = Context;
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
            ViewData["DepartmentId"] = new SelectList(_empDeptContext.Departments, "DepartmentId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empRepo.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_empDeptContext.Departments, "DepartmentId", "Name",emp.DepartmentId);
            return View(emp);
        }

        public IActionResult DeleteEmployee(int id)
        {
            _empRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee e = _empRepo.GetEmployeeById(id);
            if(e==null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_empDeptContext.Departments, "DepartmentId", "Name");
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empRepo.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }

            ViewData["DepartmentId"] = new SelectList(_empDeptContext.Departments, "DepartmentId", "Name",emp.DepartmentId);
            return View(emp);
        }
    }
}
