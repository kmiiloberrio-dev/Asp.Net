using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ent = Asp.Net_MVC.Models;
using data = Aplicacion.Entidad;

namespace Asp.Net_MVC.Mapa
{
    public class Mapear
    {
        public static void CrearMapaCategoria()
        {
            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Categoria, data.Categoria>(); createmap.CreateMap<data.Categoria, ent.Categoria>(); });
        }

        public static void CrearMapaArticulo()
        {
            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Articulo, data.Articulo>(); createmap.CreateMap<data.Articulo, ent.Articulo>(); });
        }
    }
}