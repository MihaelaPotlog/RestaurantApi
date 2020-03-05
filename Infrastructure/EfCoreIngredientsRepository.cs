using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class EfCoreIngredientsRepository: EfCoreRepository<IngredientOnStock,RestaurantContext>
    {
        public EfCoreIngredientsRepository(RestaurantContext context):base(context)
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
