using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIngredientsRepository<T> : IRepository<T> where T : class
    {
        public Task<IngredientOnStock> GetByName(string name);
    }
}
