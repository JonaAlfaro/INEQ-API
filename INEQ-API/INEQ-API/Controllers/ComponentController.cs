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
        public List<Component> Get(int id)
        {
            return db.Components.Where(e => e.Id == id).ToList();
        }

        // POST: api/Component
        public bool Post(int id, string descripcion, string tipocomponente ,string equipoid,string activo,string equipotipoid)
        {
            var c = new Component()
            {
                Id=id,
                ComponentTypeId = Convert.ToInt16(tipocomponente),
                Description = descripcion,
                EquipmentId = Convert.ToInt16(equipoid),
                Active = Convert.ToBoolean(activo),
                EquipmentTypeId = Convert.ToInt16(equipotipoid)

            };
            db.Components.Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Component/5
        public bool Put(int id, string descripcion, string tipocomponente, string equipoid, string equipotipoid, string activo)
        {
            var c = new Component()
            {
                Id = id,
                ComponentTypeId = Convert.ToInt16(tipocomponente),
                Description = descripcion,
                EquipmentId = Convert.ToInt16(equipoid),
                Active = Convert.ToBoolean(activo),
                EquipmentTypeId = Convert.ToInt16(equipotipoid)    
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
