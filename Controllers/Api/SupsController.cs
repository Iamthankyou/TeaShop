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
    public class SupsController : ApiController
    {
        private TeaEntities db = new TeaEntities();

        // GET: api/Sups
        public IQueryable<Sup> GetSups()
        {
            return db.Sups;
        }

        // GET: api/Sups/5
        [ResponseType(typeof(Sup))]
        public IHttpActionResult GetSup(int id)
        {
            Sup sup = db.Sups.Find(id);
            if (sup == null)
            {
                return NotFound();
            }

            return Ok(sup);
        }

        // PUT: api/Sups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSup(int id, Sup sup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sup.SupId)
            {
                return BadRequest();
            }

            db.Entry(sup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupExists(id))
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

        // POST: api/Sups
        [ResponseType(typeof(Sup))]
        public IHttpActionResult PostSup(Sup sup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sups.Add(sup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sup.SupId }, sup);
        }

        // DELETE: api/Sups/5
        [ResponseType(typeof(Sup))]
        public IHttpActionResult DeleteSup(int id)
        {
            Sup sup = db.Sups.Find(id);
            if (sup == null)
            {
                return NotFound();
            }

            db.Sups.Remove(sup);
            db.SaveChanges();

            return Ok(sup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupExists(int id)
        {
            return db.Sups.Count(e => e.SupId == id) > 0;
        }
    }
}