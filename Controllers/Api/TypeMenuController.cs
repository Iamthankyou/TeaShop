using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeaMVC.Models;
using Type = TeaMVC.Models.Type;

namespace TeaMVC.Controllers.Api
{
    public class TypeMenuController : ApiController
    {
        TeaEntities storeDB = new TeaEntities();

        // GET: api/TypeMenu
        public IEnumerable<Type> Get()
        {
            var Types = storeDB.Types.Include("Teas").OrderBy(g => g.Name);
            var model = Types.ToList();

            return model;
        }

        // GET: api/TypeMenu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TypeMenu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TypeMenu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TypeMenu/5
        public void Delete(int id)
        {
        }
    }
}
