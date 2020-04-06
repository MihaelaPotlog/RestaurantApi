using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infrastructure;

namespace Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private RestaurantContext _context;
        public IDishesRepository DishesRepository { get; }
        public IIngredientsRepository IngredientsRepository { get; }
        public IDishIngredientsRepository DishIngredientsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }

        public IOrderDishesRepository OrderDishesRepository { get; }

        public UnitOfWork(RestaurantContext context)
        {
            _context = context;
            DishesRepository = new EfCoreDishesRepository(context);
            IngredientsRepository = new EfCoreIngredientsRepository(context);
            DishIngredientsRepository = new EfCoreDishIngredientsRepository(context);
            OrdersRepository =  new EfCoreOrdersRepository(context);
            OrderDishesRepository = new EfCoreOrderDishesRepository(context);

        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
