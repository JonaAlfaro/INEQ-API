using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INEQ_API.Controllers
{
    public class StatusController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/Status
        public List<Status> Get()
        {
            return db.Status.ToList();
        }

        // GET: api/Status/5
        public List<Status> Get(int Id)
        {
            return db.Status.Where(e => e.Id == Id).ToList();
        }

        // POST: api/Status
        public bool Post(int Id, string Description, int Active)
        {
            var e = new Status
            {
                Id = Id,
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Status.Attach(e);
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Status/5
        public bool Put(string Description, int Active)
        {
            var Status = new Status
            {
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Status.Add(Status);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Status/5
        public bool Delete(string Description, int Active)
        {
            var Status = new Status
            {
                Description = Description,
                Active = Convert.ToBoolean(Active)
            };
            db.Status.Add(Status);
            return db.SaveChanges() > 0;
        }
    }
}
