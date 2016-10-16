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
                Nombre_Categoria = entidad.categoria.Nombre_Categoria
            };

            data.Producto prod = new data.Producto()
            {
                Nombre_Producto = entidad.producto.Nombre_Producto
            };

            await new app.TransaccionCategoriaProducto().RegistrarTransaccionCategoriaProducto(cate, prod);
            return View();
        }

        public ActionResult RegistrarCategoriaProductoServicio()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarCategoriaProductoServicio(ent.CategoriaTransaccion entidad)
        {

            var httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("http://localhost:8082/api/Transaccion", entidad);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoriasServicio", "Categoria");
            }
            return RedirectToAction("Error");
        }

        public ActionResult RegistrarListaCategoriaProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> RegistrarListaCategoriaProducto(ent.ListaCategoriaProductoTransaccion entidad)
        {
            bool status = false;
            data.Categoria cate = new data.Categoria()
            {
                Nombre_Categoria = entidad.Nombre_Categoria
            };

            List<data.Producto> prod = new List<data.Producto>();
            foreach (var item in entidad.DetalleProducto)
            {
                prod.Add(new data.Producto()
                {
                    Nombre_Producto = item.Nombre_Producto
                });
            }
            try
            {
                await new app.TransaccionCategoriaProducto().RegistrarListaTransaccionCategoriaProducto(cate, prod);
                status = true;
            }
            catch
            {
                status = false;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}