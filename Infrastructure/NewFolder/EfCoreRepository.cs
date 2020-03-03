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
        private readonly TContext context;

        protected EfCoreRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<bool> Delete(Guid id)
        {
            T deletedEntity = await context.Set<T>().FindAsync(id);

            if (deletedEntity == null)
                return false;
            else
            {
                context.Set<T>().Remove(deletedEntity);
                return true;
            }

        }

        public async Task<T> Get(Guid id)
        {
            return  await context.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return context.Set<T>().ToListAsync();
        }

        public async  Task Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
