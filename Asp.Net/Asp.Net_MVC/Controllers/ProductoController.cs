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

namespace Asp.Net_MVC.Controllers
{
    public class ProductoController : Controller
    {
        public ProductoController()
        {
            map.Mapear.CrearMapaProducto();
        }

        // GET: Producto
        public ActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Producto(ent.Producto entidad)
        {
            var _entidad = Mapper.Map<ent.Producto, data.Producto>(entidad);
            await new app.Producto().Registrar(_entidad);
            return RedirectToAction("ListarProductos");
        }

        public async Task<ActionResult> ListarProductos()
        {
            IEnumerable<data.Producto> listar = await new app.Producto().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Producto> cate = mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Producto>>(listar);
            return View(cate);
        }

        public async Task<ActionResult> ModificarProducto(int Id)
        {
            data.Producto listar = await new app.Producto().BuscarID(Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            ent.Producto cate = mapper.Map<data.Producto, ent.Producto>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> ModificarProducto(ent.Producto entidad)
        {
            var _entidad = Mapper.Map<ent.Producto, data.Producto>(entidad);
            await new app.Producto().Modificar(_entidad);
            return RedirectToAction("ListarProductos");
        }

        public async Task<ActionResult> DetallesProducto(int Id)
        {
            data.Producto listar = await new app.Producto().BuscarID(Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            ent.Producto cate = mapper.Map<data.Producto, ent.Producto>(listar);
            return View(cate);
        }

        public async Task<ActionResult> EliminarProducto(int Id)
        {
            data.Producto listar = await new app.Producto().BuscarID(Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            ent.Producto cate = mapper.Map<data.Producto, ent.Producto>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarProducto(ent.Producto entidad)
        {
            var _entidad = Mapper.Map<ent.Producto, data.Producto>(entidad);
            await new app.Producto().Eliminar(_entidad.ID_Producto);
            return RedirectToAction("ListarProductos");
        }

        public async Task<ActionResult> BuscarProductos()
        {
            IEnumerable<data.Producto> listar = await new app.Producto().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Producto> cate = mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Producto>>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> BuscarProductos(string Nombre)
        {
            IEnumerable<data.Producto> listar;
            if (Nombre != string.Empty)
            {
                listar = await new app.Producto().Buscar(Nombre);
            }
            else
            {
                listar = await new app.Producto().TraerTodo();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Producto, ent.Producto>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Producto> cate = mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Producto>>(listar);
            return View(cate);
        }

    }
}