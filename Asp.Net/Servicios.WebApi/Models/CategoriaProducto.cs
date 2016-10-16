using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ent = Aplicacion.Entidad;

namespace Servicios.WebApi.Models
{
    public class CategoriaProducto
    {
        public ent.Categoria categoria { get; set; }
        public ent.Producto producto { get; set; }
    }
}