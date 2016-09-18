using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class WarehouseController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Warehouse
        public List<Warehouse> Get()
        {
            return db.Warehouses.ToList();
        }

        // GET: api/Warehouse/5
        public List<Warehouse> Get(int id, string Descripcion, string IS, string Responsable, bool Activo)
        {
            return db.Warehouses.Where(e => e.Id == id && e.Description == Descripcion &&
            e.IS == IS && e.Responsable == Responsable && e.Active == Activo).ToList();
        }

        // POST: api/Warehouse
        public bool Post(int id, string Descripcion, string IS, string Responsable, string Activo)
        {
            var e = new Warehouse()
            {
                Id = id,
                Description = Descripcion,
                IS = IS,
                Responsable = Responsable,
                Active = Convert.ToBoolean(Activo)
            };
            db.Warehouses.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Warehouse/5
        public bool Put(int id, string Descripcion, string IS, string Responsable, string Activo)
        {
            var e = new Warehouse()
            {
                Id = id,
                Description = Descripcion,
                IS = IS,
                Responsable = Responsable,
                Active = Convert.ToBoolean(Activo)
            };
            db.Warehouses.Add(e);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Warehouse/5
        public bool Delete(int id)
        {
            var e = db.Warehouses.Find(id);
            db.Warehouses.Attach(e);
            db.Warehouses.Remove(e);
            return db.SaveChanges() > 0;
        } 
    }
}
