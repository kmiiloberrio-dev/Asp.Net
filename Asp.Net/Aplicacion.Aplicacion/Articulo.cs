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
        public Articulo()
        {
            map.Mapear.CrearMapaArticulo();
        }

        public async Task Registrar(ent.Articulo entidad)
        {
            var _entidad = Mapper.Map<ent.Articulo, data.Articulos>(entidad);
            await new dom.Articulo().Registrar(_entidad);
        }
    }
}
