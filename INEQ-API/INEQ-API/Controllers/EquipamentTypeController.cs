using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class EquipamentTypeController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/EquipamentType
        public List<EquipamentType> Get()
        {
            return db.EquipmentTypes.ToList();
        }

        // GET: api/EquipamentType/5
        public List<EquipamentType> Get(int id)
        {
            return db.EquipmentTypes.Where(e => e.Id == id).ToList();
        }

        // POST: api/EquipamentType
        public bool Post(int id, string Descripcion, int Use, int Guarante, bool Activo)
        {
            var d = new EquipamentType()
            {
                Id = id,
                Description = Descripcion,
                UsefulLife = Use,
                GuaranteeDuration = Guarante,
                Active = Convert.ToBoolean(Activo)
            };
            db.EquipmentTypes.Attach(d);
            db.Configuration.ValidateOnSaveEnabled = true;
            db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        // PUT: api/EquipamentType/5
        public bool Put(int id, string Descripcion, int Use, int Guarante, bool Activo)
        {
            var d = new EquipamentType()
            {
                Id = id,
                Description = Descripcion,
                UsefulLife = Use,
                GuaranteeDuration = Guarante,
                Active = Convert.ToBoolean(Activo)
            };
            db.EquipmentTypes.Add(d);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/EquipamentType/5
        public bool Delete(int id)
        {
            var d = db.EquipmentTypes.Find(id);
            db.EquipmentTypes.Attach(d);
            db.EquipmentTypes.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
