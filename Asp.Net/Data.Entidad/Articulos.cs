namespace Data.Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Articulos
    {
        [Key]
        public int ID_Articulos { get; set; }

        [StringLength(50)]
        public string Marca { get; set; }

        public int? Año { get; set; }

        public string Descripción { get; set; }

        public byte[] Manual { get; set; }

        [StringLength(500)]
        public string FIleName { get; set; }

        [StringLength(500)]
        public string ContentType { get; set; }

        public int ID_Producto { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
