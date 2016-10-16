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
        public async Task<HttpResponseMessage> Get(int id)
        {
            var dato = await new app.Categoria().TraerUnoPorId(id);
            var httpResponseMessage = Request.CreateResponse<ent.Categoria>(HttpStatusCode.OK, dato);
            httpResponseMessage.Headers.Add("Access-Control-Allow-Origin", "*");
            httpResponseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(1)
            };
            return httpResponseMessage;
        }

        // POST: api/Categoria
        public async Task<HttpResponseMessage> PostCategoria(ent.Categoria categoria)
        {
            try
            {
                await new app.Categoria().Registrar(categoria);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categoria);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categoria.ID_Categoria }));
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // PUT: api/Categoria/5
        [HttpPut]
        public async Task<HttpResponseMessage> PutCategoria(ent.Categoria categoria)
        {
            try
            {
                await new app.Categoria().Modificar(categoria);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categoria);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Categoria/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                ent.Categoria cate = await new app.Categoria().TraerUnoPorId(id);
                await new app.Categoria().Eliminar(cate);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, id);
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
