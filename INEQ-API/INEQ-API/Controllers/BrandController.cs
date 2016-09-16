using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class BrandController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Brand
        public List<Brand> Get()
        {
            return db.Brands.ToList();
        }

        // GET: api/Brand/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
