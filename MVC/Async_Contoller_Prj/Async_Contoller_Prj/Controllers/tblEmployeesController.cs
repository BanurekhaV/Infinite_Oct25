using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Async_Contoller_Prj.Models;

namespace Async_Contoller_Prj.Controllers
{
    public class tblEmployeesController : Controller
    {
        private InfiniteEntities1 db = new InfiniteEntities1();

        // GET: tblEmployees
        public async Task<ActionResult> Index()
        {
            var tblEmployees = db.tblEmployees.Include(t => t.tblDepartment);
            return View(await tblEmployees.ToListAsync());
        }

        // GET: tblEmployees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = await db.tblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: tblEmployees/Create
        public ActionResult Create()
        {
            ViewBag.deptid = new SelectList(db.tblDepartments, "Deptid", "Deptname");
            return View();
        }

        // POST: tblEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "empid,empname,gender,salary,deptid")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblEmployee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.deptid = new SelectList(db.tblDepartments, "Deptid", "Deptname", tblEmployee.deptid);
            return View(tblEmployee);
        }

        // GET: tblEmployees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = await db.tblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.deptid = new SelectList(db.tblDepartments, "Deptid", "Deptname", tblEmployee.deptid);
            return View(tblEmployee);
        }

        // POST: tblEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "empid,empname,gender,salary,deptid")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.deptid = new SelectList(db.tblDepartments, "Deptid", "Deptname", tblEmployee.deptid);
            return View(tblEmployee);
        }

        // GET: tblEmployees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = await db.tblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: tblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = await db.tblEmployees.FindAsync(id);
            db.tblEmployees.Remove(tblEmployee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
