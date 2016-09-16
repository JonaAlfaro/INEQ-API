using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class ComponentController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Component
        public List<Component> Get()
        {
            return db.Components.ToList();
        }
        // GET: api/Component/5
        public List<Component> Get(string Descripcion)
        {
            return db.Components.Where(e => e.Description == Descripcion).ToList();
        }

        // POST: api/Component
        public bool Post(string Descripcion, string compontentType)
        {
            var c = new Component()
            {
                ComponentTypeId = Convert.ToInt16(compontentType),
                Description = Descripcion
            };
            db.Components.Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Component/5
        public bool Put(int id,string component, string CompontentType, string active)
        {
            var c = new Component()
            {  
                Id = id,
                Description = component,
                ComponentTypeId = Convert.ToInt16(CompontentType),
                Active = Convert.ToBoolean(active)

            };
            db.Components.Add(c);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Component/5
        public void Delete(int id)
        {
        }
    }
}
