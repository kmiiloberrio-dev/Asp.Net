using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Aplicacion.Entidad;
using data = Data.Entidad;
using map = Mapa;
using dom = Dominio;
using AutoMapper;

namespace Aplicacion.Aplicacion
{
    public class Producto
    {

        public async Task Registrar(ent.Producto entidad)
        {
            map.Mapear.CrearMapaProducto();
            var _entidad = Mapper.Map<ent.Producto, data.Producto>(entidad);
            await new dom.Producto().Registrar(_entidad);
        }

        public async Task Modificar(ent.Producto entidad)
        {
            map.Mapear.CrearMapaProducto();
            var _entidad = Mapper.Map<ent.Producto, data.Producto>(entidad);
            await new dom.Producto().Modificar(_entidad);
        }

        public async Task Eliminar(int id)
        {
            await new dom.Producto().Eliminar(id);
        }

        public async Task<IEnumerable<ent.Producto>> TraerTodo()
        {
            map.Mapear.CrearMapaProducto();
            var DetalleQuery = await new dom.Producto().TraerTodo();
            var Resultado = Mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Producto>>(DetalleQuery);
            return Resultado;
        }

        public async Task<IEnumerable<ent.Producto>> Buscar(string nombre)
        {
            map.Mapear.CrearMapaProducto();
            var DetalleQuery = await new dom.Producto().Buscar(nombre);
            var Resultado = Mapper.Map<IEnumerable<data.Producto>, IEnumerable<ent.Producto>>(DetalleQuery);
            return Resultado;
        }

        public async Task<ent.Producto> BuscarID(int Id)
        {
            map.Mapear.CrearMapaProducto();
            var DetalleQuery = await new dom.Producto().BuscarID(Id);
            var Resultado = Mapper.Map<data.Producto, ent.Producto>(DetalleQuery);
            return Resultado;
        }
    }
}
