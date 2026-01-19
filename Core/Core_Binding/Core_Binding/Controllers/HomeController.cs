using Core_Binding.CustomBindings;
using Core_Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Core_Binding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //check model bindings
        [HttpGet]
        public IActionResult GetDetails([ModelBinder(typeof(CommaSeperatedModel))] List<int> Ids)
        {
            return Ok(Ids);
        }
        

        public IActionResult Index()
        {
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
