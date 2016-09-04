using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Data.Entidad;
using Data.Modelo;
using Data.Repositorio;

namespace Dominio
{
    public class Categoria
    {
        Repositorio<ent.Categoria> _repositorio = new Repositorio<ent.Categoria>(new Modelo());

        public async Task Registrar(ent.Categoria entidad)
        {
            _repositorio.Adicionar(entidad);
            await _repositorio.Grabar();
        }

        public async Task Modificar(ent.Categoria entidad)
        {
            _repositorio.Modificar(entidad);
            await _repositorio.Grabar();
        }

        public async Task Eliminar(ent.Categoria entidad)
        {
            _repositorio.Eliminar(entidad);
            await _repositorio.Grabar();
        }

        public async Task<IEnumerable<ent.Categoria>> Buscar(string Nombre)
        {
            return await _repositorio.Buscar(x => x.Nombre_Categoria == Nombre);
        }

        public async Task<ent.Categoria> TraerUno(string Nombre)
        {
            return await _repositorio.TraerUno(x => x.Nombre_Categoria == Nombre);
        }

        public async Task<ent.Categoria> TraerUnoPorId(int Id)
        {
            return await _repositorio.TraerUnoPorId(Id);
        }

        public async Task<IEnumerable<ent.Categoria>> TraerTodo()
        {
            return await _repositorio.TraerTodo();
        }
    }
}
