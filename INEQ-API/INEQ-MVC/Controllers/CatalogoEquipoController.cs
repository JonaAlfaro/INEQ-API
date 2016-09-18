using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace INEQ_MVC.Controllers
{
    public class CatalogoEquipoController : ApiController
    {
        // GET: api/CatalogoEquipo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CatalogoEquipo/5
        public async Task<ActionResult> Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60504/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/ComponentType" + id);
                return await response.Content.ReadAsAsync<ActionResult>();
            }
        }

        // POST: api/CatalogoEquipo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CatalogoEquipo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CatalogoEquipo/5
        public void Delete(int id)
        {
        }
    }
}
