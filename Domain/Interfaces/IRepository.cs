using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Update(T entity);
        Task<bool> Delete(Guid id);

    }
}
