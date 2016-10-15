using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Aplicacion.Entidad;
using data = Data.Entidad;
using AutoMapper;

namespace Mapa
{
    public class Mapear
    {
        public static void CrearMapaCategoria()
        {
            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Categoria, data.Categoria>(); createmap.CreateMap<data.Categoria, ent.Categoria>(); });

        }

        public static void CrearMapaArticulo()
        {

            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Articulo, data.Articulos>(); createmap.CreateMap<data.Articulos, ent.Articulo>(); });

        }

        public static void CrearMapaProducto()
        {
            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Producto, data.Producto>(); createmap.CreateMap<data.Producto, ent.Producto>(); });

        }
    }
}
