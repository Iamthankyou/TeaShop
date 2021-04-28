using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeaMVC.Controllers.Api
{
    public class DetailController : ApiController
    {
        // GET: api/Detail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Detail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Detail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Detail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Detail/5
        public void Delete(int id)
        {
        }
    }
}
