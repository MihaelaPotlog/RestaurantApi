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
    public class EfCoreDishesRepository : EfCoreBaseRepository<Dish, RestaurantContext>, IDishesRepository
    {
        public EfCoreDishesRepository(RestaurantContext context) : base(context)
        {

        }
        public override async Task<Dish> Get(Guid id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            _context.Entry(dish).Collection(d => d.DishIngredients)
                                .Load();
            return dish;
        }

        public override async Task<List<Dish>> GetAll()
        {
            return await _context.Dishes.Include(dish => dish.DishIngredients)
                                        .ThenInclude(dishIngredient => dishIngredient.Ingredient)
                                        .ToListAsync();
        }

    }
}
