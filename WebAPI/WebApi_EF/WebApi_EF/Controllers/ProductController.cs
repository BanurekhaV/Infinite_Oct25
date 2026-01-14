using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApi_EF.Models;

namespace WebApi_EF.Controllers
{
    public class ProductController : ApiController
    {
        private InfiniteEntities1 db  = new InfiniteEntities1();

        public IQueryable<tblProduct> GetProducts()
        {
            return db.tblProducts;
        }

        [ResponseType(typeof(tblProduct))]
        public IHttpActionResult GetProduct(int id)
        {
            tblProduct product = db.tblProducts.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(tblProduct product) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //our own post
        [HttpPost]
        public IHttpActionResult PostNewproduct([FromBody] tblProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation Failed");
            }
            db.tblProducts.Add(product);
            db.SaveChanges();
            return Ok("Success");
        }

        [ResponseType(typeof(tblProduct))]
        public IHttpActionResult DeleteProduct(int id)
        {
            tblProduct product = db.tblProducts.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            db.tblProducts.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }
    }
}
