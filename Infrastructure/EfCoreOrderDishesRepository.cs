using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.NewFolder;

namespace Infrastructure
{
    public class EfCoreOrderDishesRepository:EfCoreBaseRepository<OrderDish, RestaurantContext>, IOrderDishesRepository
    {
        public EfCoreOrderDishesRepository(RestaurantContext context):base(context)
        {
            
        }
    }
}
