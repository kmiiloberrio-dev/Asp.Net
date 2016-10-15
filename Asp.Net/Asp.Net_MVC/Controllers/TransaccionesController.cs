using System.Collections.Generic;
using System.Web.Mvc;
using ent = Asp.Net_MVC.Models;
using data = Aplicacion.Entidad;
using app = Aplicacion.Aplicacion;
using AutoMapper;
using map = Asp.Net_MVC.Mapa;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Asp.Net_MVC.Controllers
{
    public class TransaccionesController : Controller
    {

        // GET: Transacciones
        public ActionResult RegistrarCategoriaProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarCategoriaProducto(ent.CategoriaTransaccion entidad)
        {
            data.Categoria cate = new data.Categoria()
            {
                Nombre_Categoria = entidad.Nombre_Categoria
            };

            data.Producto prod = new data.Producto()
            {
                Nombre_Producto = entidad.producto.Nombre_Producto
            };

            await new app.TransaccionCategoriaProducto().RegistrarTransaccionCategoriaProducto(cate, prod);
            return View();
        }
    }
}