using Core_EF_Codefirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Core_EF_Codefirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 1,
                Name = "Babitha",
                Email = "boby@email.com",
                Position = "Quality Engg",
                DepartmentId = 2,
            };
            ViewData["emp"] = employee;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
