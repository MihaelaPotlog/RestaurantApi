using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Interfaces;
using Infrastructure.NewFolder;

namespace Infrastructure
{
    public class EfCoreOrdersRepository:EfCoreBaseRepository<Order, RestaurantContext>, IOrdersRepository
    {
        public EfCoreOrdersRepository(RestaurantContext context):base(context)
        {
            
        }
    }
}
