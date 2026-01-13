using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Client.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace WebApi_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //action method to display all products
        public ActionResult DisplayProducts()
        {
            IEnumerable<MVCProduct> productslist = null;

            using(var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44368/api/");
                var responsetalk = webclient.GetAsync("product");
                responsetalk.Wait();

                var result = responsetalk.Result;
                if(result.IsSuccessStatusCode)
                {
                    var resultdata = result.Content.ReadAsStringAsync().Result;
                    productslist = JsonConvert.DeserializeObject<List<MVCProduct>>(resultdata);
                }
                else
                {
                    productslist = Enumerable.Empty<MVCProduct>();
                }
                return View(productslist);
            }
        }
    }
}