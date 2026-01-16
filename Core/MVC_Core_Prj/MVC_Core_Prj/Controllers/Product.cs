using Microsoft.AspNetCore.Mvc;
using MVC_Core_Prj.Services;

namespace MVC_Core_Prj.Controllers
{
    public class Product : Controller
    {
        private readonly IProductService _productService;

        public Product(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var productdetails = _productService.GetAllProducts();
            return View(productdetails);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if(product == null) 
                return NotFound();
            return View(product);
        }
    }
}
