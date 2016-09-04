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
        public static void CrearMapa()
        {
            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Categoria, data.Categoria>(); createmap.CreateMap<data.Categoria, ent.Categoria>(); });
        }
    }
}