using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class ComponentTypeController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/ComponentType
        public List<ComponentType> Get()
        {
            return db.ComponentTypes.ToList();
        }

        // GET: api/ComponentType/5
        public List<ComponentType> Get(int id)
        {
            return db.ComponentTypes.Where(e => e.Id == id).ToList();
        }

        // POST: api/ComponentType
        public bool Post(string description, string id)
        {
            var c = new ComponentType()
            {
                Id = Convert.ToInt16(id),
              Description = description
            };
            db.Components.Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/ComponentType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ComponentType/5
        public void Delete(int id)
        {
        }
    }
}
