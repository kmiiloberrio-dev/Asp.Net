using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Entidad
{
    public class Categoria
    {
        [Key]
        public int ID_Categoria { get; set; }

        [StringLength(50)]
        public string Nombre_Categoria { get; set; }
    }
}
