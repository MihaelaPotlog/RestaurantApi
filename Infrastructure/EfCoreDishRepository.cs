using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Infrastructure.NewFolder;

namespace Infrastructure
{
    public sealed class EfCoreDishRepository:EfCoreRepository<Dish, RestaurantContext>
    {
        public EfCoreDishRepository(RestaurantContext context):base(context)
        {
            
        }
    }
}
