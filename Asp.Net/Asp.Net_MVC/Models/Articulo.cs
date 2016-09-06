using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_MVC.Models
{
    public class Articulo
    {
        [Key]
        public int ID_Articulos { get; set; }

        [StringLength(50)]
        public string Marca { get; set; }

        public int? Año { get; set; }

        public string Descripción { get; set; }

        public HttpPostedFileBase File { get; set; }
        public byte[] Manual { get; set; }

        [StringLength(500)]
        public string FIleName { get; set; }

        [StringLength(500)]
        public string ContentType { get; set; }

        public int ID_Producto { get; set; }
    }
}