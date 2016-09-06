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
    public class Categoria
    {
        public Categoria()
        {
            map.Mapear.CrearMapaCategoria();
        }

        public async Task Registrar(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new dom.Categoria().Registrar(_entidad);
        }

        public async Task Modificar(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new dom.Categoria().Modificar(_entidad);
        }

        public async Task Eliminar(ent.Categoria entidad)
        {
            var _entidad = Mapper.Map<ent.Categoria, data.Categoria>(entidad);
            await new dom.Categoria().Eliminar(_entidad);
        }

        public async Task<IEnumerable<ent.Categoria>> TraerTodo()
        {
            var DetalleQuery = await new dom.Categoria().TraerTodo();
            var Resultado = Mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(DetalleQuery);
            return Resultado;
        }

        public async Task<IEnumerable<ent.Categoria>> Buscar(string Nombre)
        {
            var DetalleQuery = await new dom.Categoria().Buscar(Nombre);
            var Resultado = Mapper.Map<IEnumerable<data.Categoria>, IEnumerable<ent.Categoria>>(DetalleQuery);
            return Resultado;
        }

        public async Task<ent.Categoria> TraerUno(string Nombre)
        {
            var DetalleQuery = await new dom.Categoria().TraerUno(Nombre);
            var Resultado = Mapper.Map<data.Categoria, ent.Categoria>(DetalleQuery);
            return Resultado;
        }

        public async Task<ent.Categoria> TraerUnoPorId(int Id)
        {
            var DetalleQuery = await new dom.Categoria().TraerUnoPorId(Id);
            var Resultado = Mapper.Map<data.Categoria, ent.Categoria>(DetalleQuery);
            return Resultado;
        }

    }
}
