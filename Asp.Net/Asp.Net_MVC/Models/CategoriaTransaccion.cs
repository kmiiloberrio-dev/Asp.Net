using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_MVC.Models
{
    public class CategoriaTransaccion
    {
        public Categoria categoria { get; set; }

        public Producto producto { get; set; }
    }

    public class ListaCategoriaProductoTransaccion
    {
        [Key]
        public int ID_Categoria { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Nombre Categoria")]
        public string Nombre_Categoria { get; set; }

        public List<Producto> DetalleProducto { get; set; }
    }

    public class ListaCategoriaProductoTransaccionServicio
    {
        public Categoria categoria { get; set; }

        public List<Producto> producto { get; set; }
    }
}