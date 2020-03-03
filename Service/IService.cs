using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IService
    {
        public Task<Dish> Get(Guid id);

        public Task<bool> Delete(Guid id);

        public Task Update(Dish dish);

        public Task<List<Dish>> GetAll();

    }
}
