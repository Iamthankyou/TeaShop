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
using TeaMVC.Models;

namespace TeaMVC.Controllers.Api
{
    public class TeasController : ApiController
    {
        private TeaEntities db = new TeaEntities();

        // GET: api/Teas
        public IQueryable<Tea> GetTeas()
        {
            return db.Teas;
        }

        // GET: api/Teas/5
        [ResponseType(typeof(Tea))]
        public IHttpActionResult GetTea(int id)
        {
            Tea tea = db.Teas.Find(id);

            if (tea == null)
            {
                return NotFound();
            }

            return Ok(tea);
        }

        // PUT: api/Teas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTea(int id, Tea tea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tea.TeaId)
            {
                return BadRequest();
            }

            db.Entry(tea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeaExists(id))
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

        // POST: api/Teas
        [ResponseType(typeof(Tea))]
        public IHttpActionResult PostTea(Tea tea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teas.Add(tea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tea.TeaId }, tea);
        }

        // DELETE: api/Teas/5
        [ResponseType(typeof(Tea))]
        public IHttpActionResult DeleteTea(int id)
        {
            Tea tea = db.Teas.Find(id);
            if (tea == null)
            {
                return NotFound();
            }

            db.Teas.Remove(tea);
            db.SaveChanges();

            return Ok(tea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeaExists(int id)
        {
            return db.Teas.Count(e => e.TeaId == id) > 0;
        }
    }
}