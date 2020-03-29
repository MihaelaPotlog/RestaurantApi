using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Infrastructure.NewFolder;

namespace Infrastructure
{
    public class EfCoreDishIngredientsRepository : EfCoreBaseRepository<DishIngredient, RestaurantContext>, IDishIngredientsRepository
    {
        public EfCoreDishIngredientsRepository(RestaurantContext context) : base(context)
        {

        }

    }
}
