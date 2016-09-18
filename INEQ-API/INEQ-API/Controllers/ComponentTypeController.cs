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
        public List<ComponentType> Get(int id,string desctiption)
        {
            
            return db.ComponentTypes.Where(e => e.Id == id&&e.Description==desctiption).ToList();
        }

        // POST: api/ComponentType
        public bool Post(string id , string descripcio, string activo)
        {
            var c = new ComponentType()
            {
                Id = Convert.ToInt16(id),
              Description = descripcio,
              Active = Convert.ToBoolean(activo)
            };
            db.ComponentTypes.Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/ComponentType/5
        public bool Put(int id, string description, bool activo)
        {
            var c = new ComponentType()
            {
                Id=id,
                Description = description,
                Active = activo
            };
            db.ComponentTypes.Add(c);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/ComponentType/5
        public bool Delete(int id)
        {
            var d = db.Components.Find(id);
            db.Components.Attach(d);
            db.Components.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
