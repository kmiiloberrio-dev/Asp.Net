using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_MVC.Models
{
    public class Categoria
    {
        [Key]
        public int ID_Categoria { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Nombre Categoria")]
        public string Nombre_Categoria { get; set; }
    }
}