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
        public List<Brand> Get(int Id)
        {
            return db.Brands.Where(e => e.Id == Id).ToList();
        }

        // POST: api/Brand
        public bool Post(int Id, string Description, bool Active)
        {
            var e = new Brand()
            {
                Id = Id,
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Brands.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Brand/5
        public bool Put(int id,string Description, bool Active)
        {
            var e = new Brand()
            {
                Id = id,
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Brands.Add(e);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Brand/5
        public bool Delete(int id)
        {
            var d = db.Brands.Find(id);
            db.Brands.Attach(d);
            db.Brands.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
