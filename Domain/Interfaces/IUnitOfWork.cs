using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Service
{
    public interface IUnitOfWork
    {
        IDishesRepository DishesRepository { get; }
        IIngredientsRepository IngredientsRepository { get; }
        IDishIngredientsRepository DishIngredientsRepository { get; }
        public void Commit();
        public Task CommitAsync();
    }
}
