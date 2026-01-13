using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_EF.Models;

namespace WebApi_EF.Controllers
{
    public class tblEmployeesController : ApiController
    {
        private InfiniteEntities1 db = new InfiniteEntities1();

        // GET: api/tblEmployees
        public IQueryable<tblEmployee> GettblEmployees()
        {
            return db.tblEmployees;
        }

        // GET: api/tblEmployees/5
        [ResponseType(typeof(tblEmployee))]
        public IHttpActionResult GettblEmployee(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return Ok(tblEmployee);
        }

        // PUT: api/tblEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEmployee(int id, tblEmployee tblEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblEmployee.empid)
            {
                return BadRequest();
            }

            db.Entry(tblEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblEmployees
        [ResponseType(typeof(tblEmployee))]
        public IHttpActionResult PosttblEmployee(tblEmployee tblEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEmployees.Add(tblEmployee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblEmployeeExists(tblEmployee.empid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblEmployee.empid }, tblEmployee);
        }

        // DELETE: api/tblEmployees/5
        [ResponseType(typeof(tblEmployee))]
        public IHttpActionResult DeletetblEmployee(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            db.tblEmployees.Remove(tblEmployee);
            db.SaveChanges();

            return Ok(tblEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEmployeeExists(int id)
        {
            return db.tblEmployees.Count(e => e.empid == id) > 0;
        }
    }
}