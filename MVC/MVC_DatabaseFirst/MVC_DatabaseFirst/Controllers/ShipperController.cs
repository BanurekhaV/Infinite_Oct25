using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;

namespace MVC_DatabaseFirst.Controllers
{
    public class ShipperController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Shipper
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //1. passing data from view to controller using form collection
        //public ActionResult Create(FormCollection frm)
        //{
        //Shipper s = new Shipper();
        //s.ShipperID = Convert.ToInt32(frm["ShipperID"]);
        //s.CompanyName = frm["CompanyName"].ToString();
        //s.Phone = frm["Phone"].ToString();

        //db.Shippers.Add(s);
        //db.SaveChanges();
        //return RedirectToAction("Index");
        //}

        //2. passing data from view to controller using parameter collection
        //parameter names to match the schema attribute names
        //[ActionName("Create")]
        //public ActionResult CreatePost(string CompanyName,string Phone)
        //{
        //    Shipper s = new Shipper();
        //    s.CompanyName = CompanyName;
        //    s.Phone = Phone;
        //    db.Shippers.Add(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //3. passing data from view to controller using request object
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            Shipper s = new Shipper();
            s.ShipperID = Convert.ToInt32(Request["ShipperID"]);
            s.CompanyName = Request["CompanyName"].ToString();
            s.Phone = Request["Phone"].ToString() ;

            db.Shippers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //4. calling stored procedure
        public ActionResult SP_with_Parameter()
        {
            return View(db.CustOrdersOrders("Vinet"));
        }
    }


}

    



        

