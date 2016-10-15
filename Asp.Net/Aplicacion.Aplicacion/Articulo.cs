using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Aplicacion.Entidad;
using data = Data.Entidad;
using map = Mapa;
using dom = Dominio;
using AutoMapper;

namespace Aplicacion.Aplicacion
{
    public class Articulo
    {

        public async Task Registrar(ent.Articulo entidad)
        {
            map.Mapear.CrearMapaArticulo();
            var _entidad = Mapper.Map<ent.Articulo, data.Articulos>(entidad);
            await new dom.Articulo().Registrar(_entidad);
        }

        public async Task Modificar(ent.Articulo entidad)
        {
            map.Mapear.CrearMapaArticulo();
            var _entidad = Mapper.Map<ent.Articulo, data.Articulos>(entidad);
            await new dom.Articulo().Modificar(_entidad);
        }

        public async Task Eliminar(ent.Articulo entidad)
        {
            map.Mapear.CrearMapaArticulo();
            var _entidad = Mapper.Map<ent.Articulo, data.Articulos>(entidad);
            await new dom.Articulo().Eliminar(_entidad);
        }


    }
}
