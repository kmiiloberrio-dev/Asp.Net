namespace Data.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Data.Entidad;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>()
                .Property(e => e.Descripción)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Articulos)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);
        }
    }
}
