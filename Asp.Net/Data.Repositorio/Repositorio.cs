using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repositorio(DbContext contexto)
        {
            _context = contexto;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> TraerTodo()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public IEnumerable<T> TraerTodoDev()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> Buscar(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return await _context.Set<T>().Where(predicado).ToListAsync();
        }

        public async Task<T> TraerUno(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return await _context.Set<T>().Where(predicado).FirstOrDefaultAsync();
        }

        public async Task<T> TraerUnoPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Adicionar(T entidad)
        {
            if (_context.Entry<T>(entidad).State != System.Data.Entity.EntityState.Detached)
                _context.Entry<T>(entidad).State = System.Data.Entity.EntityState.Added;
            else
                _context.Set<T>().Add(entidad);
        }

        public void Modificar(T entidad)
        {
            if (_context.Entry<T>(entidad).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entidad);
            _context.Entry<T>(entidad).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(T entidad)
        {
            if (_context.Entry<T>(entidad).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entidad);
            _context.Entry<T>(entidad).State = System.Data.Entity.EntityState.Deleted;
        }

        public async Task Grabar()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            return;
        }
    }
}
