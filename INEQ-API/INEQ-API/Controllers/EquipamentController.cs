using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class EquipamentController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Equipament
        public List<Equipament> Get()
        {
            return db.Equipments.ToList();
        }

        // GET: api/Equipament/5
        public List<Equipament> Get( int id,int EquipmentTypeId, int BrandId, int ModelId, int StatusId, string serie, string softekid, bool activo)
        {
            return db.Equipments.Where(e =>e.Id==id&& e.EquipmentTypeId == EquipmentTypeId && e.BrandId == BrandId
            && e.ModelId == ModelId && e.StatusId==StatusId&& e.Serie==serie&& e.SofttekId==softekid&& e.Active ==activo ).ToList();
        }

        // POST: api/Equipament
        public bool Post(string softekid, string tipoEquipo, string marca, string modelo, string serie, string bodega, string status, string fecha, string activo)
        {
            var e = new Equipament()
            {
                SofttekId = softekid,
                EquipmentTypeId = Convert.ToInt16(tipoEquipo),
                BrandId = Convert.ToInt16(marca),
                ModelId = Convert.ToInt16(modelo),
                Serie = serie,
                WarehouseId = Convert.ToInt16(bodega),
                StatusId = Convert.ToInt16(status),
                EntryDate = Convert.ToDateTime(fecha),
                Active = Convert.ToBoolean(activo)
                
            };
            db.Equipments.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }
    
        // PUT: api/Equipament/5
        public bool Put(int id, string softekid, string tipoEquipo, string marca, string modelo, string serie, string bodega, string status, string fecha, string activo)
        {
            var e = new Equipament ()
            { 
                Id=id,
                SofttekId = softekid,
                EquipmentTypeId = Convert.ToInt16(tipoEquipo),
                BrandId = Convert.ToInt16(marca),
                ModelId = Convert.ToInt16(modelo),
                Serie = serie,
                WarehouseId = Convert.ToInt16(bodega),
                StatusId = Convert.ToInt16(status),
                EntryDate = Convert.ToDateTime(fecha),
                Active = Convert.ToBoolean(activo)

            };
            db.Equipments.Add(e);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Equipament/5
        public bool Delete(int id)
        {
            var d = db.Equipments.Find(id);
            db.Equipments.Attach(d);
            db.Equipments.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
