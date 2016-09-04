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
        public static void CrearMapa()
        {

            Mapper.Initialize(createmap => { createmap.CreateMap<ent.Categoria, data.Categoria>(); createmap.CreateMap<data.Categoria, ent.Categoria>(); });

        }
    }
}
