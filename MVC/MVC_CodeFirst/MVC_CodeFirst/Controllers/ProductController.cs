using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CodeFirst.Models;
using MVC_CodeFirst.Repository;

namespace MVC_CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository<Products> _productsRepo = null;

        //controller constructor

        public ProductController()
        {
            _productsRepo = new ProductRepository<Products>();
        }
        // GET: Product
        //all products
        public ActionResult Index()
        {
            var products = _productsRepo.GetAll();
            return View(products);
        }

        //2. creating a new product
        public ActionResult Create()
        {
            return View();
        }

        //2.1 create post
        [HttpPost]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                _productsRepo.Insert(products);
                _productsRepo.Save();
                return RedirectToAction("Index");
            }
            return View(products);
        }
    }
}