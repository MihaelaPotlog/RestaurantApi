using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IIngredientsService
    {
        public Task<IngredientOnStock> Get(Guid id);
        public Task<IList<IngredientOnStock>> GetAll();

        // public Task<bool> Delete(Guid id);
        //
        // public Task Update(Dish dish);
        //
        // public Task<List<T>> GetAll();

    }
}
