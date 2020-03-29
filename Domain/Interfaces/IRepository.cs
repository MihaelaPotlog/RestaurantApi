using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Update(T entity);
        Task Add(T entity);
        Task<bool> Delete(Guid id);
        Task Delete(T entity);

    }
}
