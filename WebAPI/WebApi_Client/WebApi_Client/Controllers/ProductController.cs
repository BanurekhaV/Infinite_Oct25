using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Client.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44368/api/");
                var responsetalk = webclient.GetAsync("product");
                responsetalk.Wait();

                var result = responsetalk.Result;
                if (result.IsSuccessStatusCode)
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVCProduct mvcprd)
        {
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44368/api/");
                var posttalk = webclient.PostAsJsonAsync<MVCProduct>("product", mvcprd);
                posttalk.Wait();
                var dataresult = posttalk.Result;

                if (dataresult.IsSuccessStatusCode)
                {
                    return RedirectToAction("DisplayProducts");
                }
                ModelState.AddModelError(String.Empty, "Insertion Failed.. try again later");
                return View(mvcprd);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCProduct product = null;
            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri("https://localhost:44368/api/");

                var edittalk = webclient.GetAsync("product/" + id).Result;
                if (edittalk.IsSuccessStatusCode)
                {
                    var resultdata = edittalk.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<MVCProduct>(resultdata);
                }
                else
                {
                    ModelState.AddModelError("", "Some Error Occurred..");
                }
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MVCProduct p)
        {
            if (ModelState.IsValid)
            {
                using (var webclient = new HttpClient())
                {
                    webclient.BaseAddress = new Uri("https://localhost:44368/api/");
                    var response = await webclient.PutAsJsonAsync("product", p);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("DisplayProducts");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error Occurred..");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}