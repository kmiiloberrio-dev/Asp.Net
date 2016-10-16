using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ent = Aplicacion.Entidad;
using app = Aplicacion.Aplicacion;
using mod = Servicios.WebApi.Models;

namespace Servicios.WebApi.Controllers
{
    public class TransaccionController : ApiController
    {

        // POST: api/Transaccion
        public async Task<HttpResponseMessage> PostTransaccionCategoriaProducto(mod.CategoriaProducto cateprod)
        {
            try
            {
                ent.Categoria cate = cateprod.categoria;
                ent.Producto prod = cateprod.producto;
                await new app.TransaccionCategoriaProducto().RegistrarTransaccionCategoriaProducto(cate, prod);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cate.Nombre_Categoria);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
