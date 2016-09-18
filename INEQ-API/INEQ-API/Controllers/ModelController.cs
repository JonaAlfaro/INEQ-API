using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class ModelController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Model
        public List<Model> Get()
        {
            return db.Models.ToList();
        }

        // GET: api/Model/5
        public List<Model> Get(int id)
        {
            return db.Models.Where(e => e.Id == id).ToList();
        }

        // POST: api/Model
        public bool Post(int id, string Description, bool Active, int BrandId)
        {
            var e = new Model()
            {
                Id = id,
                Description = Description,
                Active = Convert.ToBoolean(Active),
                BrandId = BrandId
            };
            db.Models.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Model/5
        public bool Put(int id,string Description,bool Active,int BrandId)
        {
            var c = new Model()
            {
                Id = id,
                Description = Description,
                Active = Convert.ToBoolean(Active),
                BrandId = BrandId
            };
            db.Models.Add(c);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Model/5
        public bool Delete(int id)
        {
            var Model = db.Models.Find(id);
            db.Models.Attach(Model);
            db.Models.Remove(Model);
            return db.SaveChanges() > 0;
        }
    }
}
