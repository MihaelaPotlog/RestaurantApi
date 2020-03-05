using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Infrastructure.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    class EfCoreIngredientsRepositoryTest: EfCoreRepository<IngredientOnStock, RestaurantContext>, IIngredientsRepository<IngredientOnStock>
    {
        public EfCoreIngredientsRepositoryTest(RestaurantContext context):base(context)
        {
            
        }

        public async Task<IngredientOnStock> GetByName(string name)
        {
            IngredientOnStock searchedIngredient = await _context.Stock.FirstOrDefaultAsync(elem => elem.Name == name);
            if (searchedIngredient == default(IngredientOnStock))
                return null;
            else
            {
                return searchedIngredient;
            }
        }
    }
}
