using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.Net_MVC.Models
{
    public class Producto
    {
        public int ID_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        public int ID_Categoria { get; set; }
    }
}