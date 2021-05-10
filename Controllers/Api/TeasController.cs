using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TeaMVC.Models;

namespace TeaMVC.Controllers.Api
{
    public class TeasController : ApiController
    {
        private TeaEntities db = new TeaEntities();

        // GET: api/Teass
        [Authorize]
        public IQueryable<Tea> GetTeas(string query=null)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                if (query[0] == 'S')
                {
                    return db.Teas.Where(f => f.Sup.Name.Contains(query.Substring(1,3).ToString()));
                }

                return db.Teas.Where(f => f.Title.Contains(query));
            }

            return db.Teas;
        }

        public async Task<HttpResponseMessage> PostFormData()
            {
                // Check if the request contains multipart/form-data.
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);

                try
                {
                    // Read the form data.
                    await Request.Content.ReadAsMultipartAsync(provider);

                    // This illustrates how to get the file names.
                    
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (System.Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }
            }

        // GET: api/Teass/5
        [ResponseType(typeof(Tea))]
        public async Task<IHttpActionResult> GetTea(int id)
        {
            Tea tea = await db.Teas.FindAsync(id);
            if (tea == null)
            {
                return NotFound();
            }

            return Ok(tea);
        }

        // PUT: api/Teass/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTea(int id, Tea tea)
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
                await db.SaveChangesAsync();
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

        // POST: api/Teass
        [ResponseType(typeof(Tea))]
        public async Task<IHttpActionResult> PostTea(Tea tea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teas.Add(tea);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tea.TeaId }, tea);
        }

        // DELETE: api/Teass/5
        [ResponseType(typeof(Tea))]
        public async Task<IHttpActionResult> DeleteTea(int id)
        {
            Tea tea = await db.Teas.FindAsync(id);
            if (tea == null)
            {
                return NotFound();
            }

            db.Teas.Remove(tea);
            await db.SaveChangesAsync();

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