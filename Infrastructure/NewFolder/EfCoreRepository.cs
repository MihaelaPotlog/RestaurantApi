using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.NewFolder
{
    public abstract class EfCoreRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected EfCoreRepository(TContext context)
        {
            this._context = context;
        }
        public async Task<bool> Delete(Guid id)
        {
            T deletedEntity = await _context.Set<T>().FindAsync(id);

            if (deletedEntity == null)
                return false;
            else
            {
                _context.Set<T>().Remove(deletedEntity);
                return true;
            }

        }

        public async Task<T> Get(Guid id)
        {
            return  await _context.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async  Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
