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
    public class ArticuloController : Controller
    {
        public ArticuloController()
        {
            map.Mapear.CrearMapaArticulo();
        }

        public ActionResult Articulos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Articulos(ent.Articulo entidad)
        {
            byte[] Data = new byte[entidad.File.ContentLength];
            entidad.File.InputStream.Read(Data, 0, entidad.File.ContentLength);
            entidad.Manual = Data;
            entidad.ContentType = entidad.File.ContentType;
            entidad.FIleName = entidad.File.FileName;
            var _entidad = Mapper.Map<ent.Articulo, data.Articulo>(entidad);
            await new app.Articulo().Registrar(_entidad);
            return View();
        }
    }
}
