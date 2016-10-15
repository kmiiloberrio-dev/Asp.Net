using ent = Data.Entidad;
using Data.Modelo;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Dominio
{
    /// <summary>
    /// Procedimientos almacenados del lado del cliente con CODE FIRST
    /// </summary>
    public class Articulo
    {
        public async Task Registrar(ent.Articulos entidad)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
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
            catch (Exception ex)
            {
                throw new Exception("Error Registrar", ex.InnerException);
            }
        }

        public async Task Modificar(ent.Articulos entidad)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    string Query = "Update Articulos set Marca = @Marca, Año = @Año, Descripción = @Descripción, Manual=@Manual,FileName = @FileName" +
                               ",ContentType = @ContentType,ID_Producto = @ID_Producto where ID_Articulos = @ID_Articulos";
                    var marca = new SqlParameter("@Marca", entidad.Marca);
                    var anio = new SqlParameter("@Año", entidad.Año);
                    var descripcion = new SqlParameter("@Descripción", entidad.Descripción);
                    var manual = new SqlParameter("@Manual", entidad.Manual);
                    var filename = new SqlParameter("@FileName", entidad.FIleName);
                    var contentype = new SqlParameter("@Contentype", entidad.ContentType);
                    var idproducto = new SqlParameter("@ID_Producto", entidad.ID_Producto);
                    var idarticulos = new SqlParameter("@ID_Articulos", entidad.ID_Articulos);

                    await modelo.Database.ExecuteSqlCommandAsync(Query, marca, anio, descripcion, manual, filename, contentype, idproducto, idarticulos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Modificar", ex.InnerException);
            }
        }

        public async Task Eliminar(ent.Articulos entidad)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    string Query = "Delete from Articulos where ID_Articulos = @ID_Articulos";
                    var idarticulos = new SqlParameter("@ID_Articulos", entidad.ID_Articulos);
                    await modelo.Database.ExecuteSqlCommandAsync(Query, idarticulos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Eliminar", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Articulos>> TraerTodo()
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    string Query = "Select * from Articulos";
                    return await modelo.Database.SqlQuery<ent.Articulos>(Query).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerTodo", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Articulos>> Buscar(string Marca)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    string Query = "Select * from Articulos where Marca like @Marca";
                    var marca = new SqlParameter("@Marca", Marca);
                    return await modelo.Database.SqlQuery<ent.Articulos>(Query, marca).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Buscar", ex.InnerException);
            }
        }

        public async Task<ent.Articulos> TraerUnoID(int IDArticulo)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    string Query = "Select * from Articulos where ID_Articulos = @ID_Articulos";
                    var idarticulo = new SqlParameter("@ID_Articulos", IDArticulo);
                    return await modelo.Database.SqlQuery<ent.Articulos>(Query, idarticulo).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error TraerUnoID", ex.InnerException);
            }

        }
    }
}
