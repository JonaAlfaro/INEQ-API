using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace INEQ_API.Controllers
{
    public class UserController : ApiController
    {
        private INEQContext db = new INEQContext();
        // GET: api/User

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        // GET: api/User/5
        public List<User> Get(int id, string Nombre, string LastName, string UserName, string Contraseña, bool Activo)
        {
            return db.Users.Where((c) => c.Id == id && c.Name == Nombre && c.LastName == LastName && 
            c.Username == UserName && c.Password == Contraseña && c.Active == Activo).ToList(); ;
        }

        // POST: api/User
        public bool Post(int id, string Nombre, string LastName, string UserName, string Contraseña, string Activo )
        {
            var c = new User()
            {
                Id = Convert.ToInt16(id),
                Name = Nombre,
                LastName = LastName,
                Username = UserName,
                Password = Contraseña,
                Active = Convert.ToBoolean(Activo)
            };
            db.Users.Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/User/5
        public bool Put(int id,string Nombre, string LastName, string UserName, string Contraseña, string Activo)
        {
            var c = new User()
            {
                Id= Convert.ToInt16(id),
                Name = Nombre,
                LastName = LastName,
                Username = UserName,
                Password = Contraseña,
                Active = Convert.ToBoolean(Activo)
            };
            db.Users.Add(c);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/User/5
        public bool Delete(int id)
        {
            var e = db.Users.Find(id);
            db.Users.Attach(e);
            db.Users.Remove(e);
            return db.SaveChanges() > 0;
        }
    }
}
