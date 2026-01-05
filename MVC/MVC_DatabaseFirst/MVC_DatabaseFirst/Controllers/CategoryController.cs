using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;

namespace MVC_DatabaseFirst.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Category
        public ActionResult Index()
        {
            //1. The below action method uses scaffolded view
            List<Category> catlist = db.Categories.ToList();
            return View(catlist);
        }

        //2. the below action method does not use scaffolded view
        public ActionResult GetCategoryDetails()
        {
            List<Category> catlist = db.Categories.ToList();
            return View(catlist);
        }

        //3. Adding or inserting a new category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category) // passing data from view to controller thru model object 
        { 
           db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        //4 deleting category
        public ActionResult Delete(int Id)
        {
            Category c = db.Categories.Find(Id);
            return View(c);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteCategory(int Id)
        {
            Category cat = db.Categories.Find(Id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //5. category details
        public ActionResult Details(int Id)
        {
          Category category = db.Categories.Find(Id);
            return View(category);
        }

        //6. edit
        public ActionResult Edit(int Id)
        {
            Category category = db.Categories.Find(Id);
            return View(category);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Update(Category cat)
        {
            Category c = db.Categories.Find(cat.CategoryID);
            c.CategoryName = cat.CategoryName;
            c.Description = cat.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //7. sorting category by name
        public ActionResult GetCategoryByName()
        {
            List<String> sortedcatlist =(from c in db.Categories
                                         orderby c.CategoryName
                                         select c.CategoryName).ToList();

            return View(sortedcatlist);
        }
    }
}