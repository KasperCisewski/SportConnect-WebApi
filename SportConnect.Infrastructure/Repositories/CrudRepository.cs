using Microsoft.EntityFrameworkCore;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Infrastructure.Repositories
{
    public class CrudRepository<T> : IRepository<T> where T : class
    {
        protected readonly SportConnectContext _context;
        private DbSet<T> _table = null;

        public CrudRepository(SportConnectContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveById(object id)
        {
            var entity = await GetById(id);
            await Remove(entity);
        }

        public async Task Update(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
