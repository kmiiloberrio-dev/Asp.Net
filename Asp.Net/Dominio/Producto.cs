using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Data.Entidad;
using Data.Modelo;
using System.Data.SqlClient;

namespace Dominio
{
    /// <summary>
    /// Procedimientos almacenados desde SQL consumidos con CODE FIRST
    /// </summary>
    public class Producto
    {

        public async Task Registrar(ent.Producto entidad)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    var nombreproducto = new SqlParameter("@NombreProducto", entidad.Nombre_Producto);
                    var idcategoria = new SqlParameter("@ID_Categoria", entidad.ID_Categoria);

                    await modelo.Database.ExecuteSqlCommandAsync("dbo.RegistrarProducto @NombreProducto,@ID_Categoria", nombreproducto, idcategoria);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error en registrar producto", ex.InnerException);
            }
        }

        public async Task Modificar(ent.Producto entidad)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    var idproducto = new SqlParameter("@ID_Producto", entidad.ID_Producto);
                    var nombreproducto = new SqlParameter("@NombreProducto", entidad.Nombre_Producto);
                    var idcategoria = new SqlParameter("@ID_Categoria", entidad.ID_Categoria);

                    await modelo.Database.ExecuteSqlCommandAsync("dbo.RegistrarProducto @ID_Producto,@NombreProducto,@ID_Categoria@ID_Categoria", idproducto,nombreproducto, idcategoria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Modificar producto", ex.InnerException);
            }
        }

        public async Task Eliminar(int id)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    var idproducto = new SqlParameter("@ID_Producto", id);

                    await modelo.Database.ExecuteSqlCommandAsync("dbo.RegistrarProducto @ID_Producto", idproducto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Eliminar producto", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Producto>> TraerTodo()
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    return await modelo.Database.SqlQuery<ent.Producto>("dbo.ListarProducto").ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en TraerTodo producto", ex.InnerException);
            }
        }

        public async Task<IEnumerable<ent.Producto>> Buscar(string nombre)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    var nombreproducto = new SqlParameter("@NombreProducto", nombre);
                    return await modelo.Database.SqlQuery<ent.Producto>("dbo.BuscarProducto @NombreProducto", nombreproducto).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Buscar producto", ex.InnerException);
            }
        }

        public async Task<ent.Producto> BuscarID(int Id)
        {
            try
            {
                using (Modelo modelo = new Modelo())
                {
                    var idproducto = new SqlParameter("@ID_Producto", Id);
                    return await modelo.Database.SqlQuery<ent.Producto>("dbo.BuscarProductoID @ID_Producto", idproducto).FirstOrDefaultAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error Buscar ID", ex.InnerException);
            }
        }
        
    }
}
