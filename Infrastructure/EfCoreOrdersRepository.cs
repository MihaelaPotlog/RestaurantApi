using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Infrastructure.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfCoreOrdersRepository:EfCoreBaseRepository<Order, RestaurantContext>, IOrdersRepository
    {
        public EfCoreOrdersRepository(RestaurantContext context):base(context)
        {
            
        }

        public override async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                                .Include(order => order.OrderDishes)
                                    .ThenInclude(orderDish => orderDish.Dish)
                                .ToListAsync();
        }

        public  IList<Order> FindAll(Func<Order, bool> condition)
        {
            return _context.Orders
                .Include(order => order.OrderDishes)
                    .ThenInclude(orderDish => orderDish.Dish)
                .Where(condition)
                .ToList();

        }
    }
}
