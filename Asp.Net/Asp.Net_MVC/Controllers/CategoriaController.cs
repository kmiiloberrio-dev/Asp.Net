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
    public class CategoriaController : Controller
    {
        public CategoriaController()
        {
            map.Mapear.CrearMapa();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.Message = "Registrar categoria.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Categorias(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new app.Categoria().Registrar(_entidad);
            return View();
        }

        public async Task<ActionResult> ModificarCategorias(int id)
        {
            ViewBag.Message = "Modificar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> ModificarCategorias(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new app.Categoria().Modificar(_entidad);
            return View();
        }

        public async Task<ActionResult> EliminarCategorias(int id)
        {
            ViewBag.Message = "Eliminar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarCategorias(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new app.Categoria().Eliminar(_entidad);
            return RedirectToAction("ListarCategorias");
        }

        public async Task<ActionResult> DetalleCategorias(int id)
        {
            ViewBag.Message = "Eliminar categoria.";
            data.Categoria listar = await new app.Categoria().TraerUnoPorId(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            ent.Categoria cate = mapper.Map<data.Categoria, ent.Categoria>(listar);
            return View(cate);
        }

        public async Task<ActionResult> ListarCategorias()
        {
            IEnumerable<data.Categoria> listar = await new app.Categoria().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        public async Task<ActionResult> BuscarCategorias()
        {
            IEnumerable<data.Categoria> listar = await new app.Categoria().TraerTodo();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        [HttpPost]
        public async Task<ActionResult> BuscarCategorias(string Nombre)
        {
            IEnumerable<data.Categoria> listar = await new app.Categoria().Buscar(Nombre);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> cate = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(listar);
            return View(cate);
        }

        public async Task<ActionResult> CategoriasServicio()
        {

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:8082/api/Categoria");
            IEnumerable<data.Categoria> cate = JsonConvert.DeserializeObject<IEnumerable<data.Categoria>>(json);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<data.Categoria, ent.Categoria>());
            var mapper = config.CreateMapper();
            IEnumerable<ent.Categoria> catelist = mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(cate);
            return View(catelist);
        }
    }
}