using Core_OtherConcepts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Core_OtherConcepts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("MyHome")]
        [Route("MyHome/Index")]
        public string Index()
        {
            return "This is Index of Home";
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("Home/Details/{id=5}")]
        public string Details(int id)
        {
            return "Details of Home " + id;
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
