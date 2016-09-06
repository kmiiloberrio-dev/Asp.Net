using ent = Data.Entidad;
using Data.Modelo;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public async Task Registrar(ent.Articulos entidad)
        {
            Modelo modelo = new Modelo();
            string Query = "insert into Articulos (Marca,Año,Descripción,Manual,FileName,ContentType,ID_Producto)"
                           + "values (@Marca, @Año, @Descripción, @Manual, @FileName, @Contentype, @ID_Producto)";
            var marca = new SqlParameter("@Marca", entidad.Marca);
            var anio = new SqlParameter("@Año", entidad.Año);
            var descripcion = new SqlParameter("@Descripción", entidad.Descripción);
            var manual = new SqlParameter("@Manual", entidad.Manual);
            var filename = new SqlParameter("@FileName", entidad.FIleName);
            var contentype = new SqlParameter("@Contentype", entidad.ContentType);
            var idproducto = new SqlParameter("@ID_Producto", entidad.ID_Producto);

            await modelo.Database.ExecuteSqlCommandAsync(Query, marca, anio, descripcion, manual, filename, contentype, idproducto);
        }
    }
}
