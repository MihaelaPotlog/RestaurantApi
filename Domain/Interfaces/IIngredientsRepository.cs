using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIngredientsRepository : IRepository<IngredientOnStock>
    {
        public Task<IngredientOnStock> GetByName(string name);
    }
}
