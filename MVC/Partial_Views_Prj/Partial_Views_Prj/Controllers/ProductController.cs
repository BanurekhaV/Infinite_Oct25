using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partial_Views_Prj.Models;

namespace Partial_Views_Prj.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products;
        public ProductController() 
        {
             products = new List<Product>()
            {
                new Product{ProductId=1, ProductName="Shoes",Category="Accessories",
                    ProductDescription="Smooth Soles for comfort",Price=3500},
                new Product{ProductId=2, ProductName="Watches",Category="Accessories",
                    ProductDescription="Smart and user friendly",Price=6500},
                new Product{ProductId=3, ProductName="Curtains",Category="Furnishings",
                    ProductDescription="Valence for Windows",Price=13500},
                new Product{ProductId=4, ProductName="Pillows",Category="Beddings",
                    ProductDescription="Memory Foam for comfort",Price=5000},
            };

        }
        // GET: Product
        public ActionResult Index()
        {           
            return View(products);
        }
    }
}