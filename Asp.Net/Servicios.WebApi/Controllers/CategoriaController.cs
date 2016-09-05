using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ent = Aplicacion.Entidad;
using app = Aplicacion.Aplicacion;

namespace Servicios.WebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public async Task<HttpResponseMessage> Get()
        {
            var dato = await new app.Categoria().TraerTodo();
            var httpResponseMessage = Request.CreateResponse<IEnumerable<ent.Categoria>>(HttpStatusCode.OK, dato);
            httpResponseMessage.Headers.Add("Access-Control-Allow-Origin", "*");
            httpResponseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(1)
            };
            return httpResponseMessage;
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }
    }
}
