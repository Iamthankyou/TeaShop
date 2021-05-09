using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeaMVC.Models;

namespace TeaMVC.Controllers.Api
{

    public class HomeController : ApiController
    {
        TeaEntities storeDB = new TeaEntities();

        // GET: api/Home
        public IEnumerable<Tea> Get()
        {
            return storeDB.Teas
                 .OrderByDescending(a => a.OrderDetails.Sum(o => o.Quantity)).Take(5);

        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }
    }
}
