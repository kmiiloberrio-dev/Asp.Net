using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> AsQueryable();
        Task<IEnumerable<T>> TraerTodo();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado);
        Task<T> TraerUno(Expression<Func<T, bool>> predicado);
        Task<T> TraerUnoPorId(int id);

        void Adicionar(T entidad);
        void Modificar(T entidad);
        void Eliminar(T entidad);

        Task Grabar();

    }
}
