using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Infrastructure.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfCoreIngredientsRepository : EfCoreBaseRepository<IngredientOnStock, RestaurantContext>, IIngredientsRepository
    {
        public EfCoreIngredientsRepository(RestaurantContext context) : base(context)
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
