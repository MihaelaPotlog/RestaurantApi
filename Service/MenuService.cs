using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Service.DTOs;
using Service.DTOs.RequestDTOs;

namespace Service
{
    public class MenuService : IDishesService
    {
        private readonly IDishesRepository _dishes;
        private readonly IIngredientsRepository _ingredients;
        private readonly IDishIngredientsRepository _dishIngredients;
        private readonly IMapper _mapper;


        public MenuService(IDishesRepository dishes, IIngredientsRepository ingredients, IDishIngredientsRepository dishIngredients, IMapper mapper)
        {
            _dishes = dishes;
            _ingredients = ingredients;
            _dishIngredients = dishIngredients;
            _mapper = mapper;
        }
        public async Task<Dish> Get(string id)
        {
            Guid.TryParse(id, out Guid dishId);
            return await _dishes.Get(dishId);
        }

        public async Task<bool> Delete(string id)
        {
            Guid.TryParse(id, out Guid dishId);
            
            var dish = await _dishes.Get(dishId);
            if (dish != null)
            {
                 await _dishes.Delete(dish);
                 return true;
            }

            return false;

        }

        public async Task Modify(string id, ModifyDishDto request)
        {
            Guid.TryParse(id, out Guid dishId);

            // var dish = await _dishes.Get(dishId);
            // if(request.Name != )

        }

        public async Task Replace(string id, ModifyDishDto request)
        {
            Guid.TryParse(id, out Guid dishId);
            var dish = await  _dishes.Get(dishId);
            dish.Name = request.Name;
            dish.Price = request.Price;
            dish.DishIngredients.Clear();
            

            foreach (var requestDishIngredient in request.DishIngredients)
            {
                var ingredient = await _ingredients.Get(requestDishIngredient.Key);
                var link = new DishIngredient()
                {
                    Dish = dish,
                    Ingredient = ingredient,
                    Quantity = requestDishIngredient.Value
                };

                await _dishIngredients.Add(link);
            }

            await _dishes.Update(dish);
        }

        public async Task<List<DishDto>> GetAll()
        {
            return _mapper.Map<List<DishDto>>(await _dishes.GetAll());
        }

        public async Task<DishDto> Create(CreateDishDto request)
        {
            IDictionary<Guid, IngredientOnStock> usedIngredients = new Dictionary<Guid, IngredientOnStock>();
            bool isAvailable = true;
            var dishIngredientsEnumerator = request.DishIngredients.GetEnumerator();

            while (dishIngredientsEnumerator.MoveNext() && isAvailable == true)
            {
                
                double quantity = dishIngredientsEnumerator.Current.Value;

                var usedIngredient = await _ingredients.Get(dishIngredientsEnumerator.Current.Key);
                if (usedIngredient == null)
                    return null;

                usedIngredients.Add(usedIngredient.Id, usedIngredient);
                if (usedIngredient.Quantity < quantity)
                    isAvailable = false;

            }
            dishIngredientsEnumerator.Dispose();

            Dish createdDish = Dish.Create(request.Name, request.Price, isAvailable);
            var id = createdDish.Id;
            await _dishes.Add(createdDish);

            dishIngredientsEnumerator = request.DishIngredients.GetEnumerator();
            while (dishIngredientsEnumerator.MoveNext())
            {
                DishIngredient link = new DishIngredient()
                {
                    Dish = createdDish,
                    Ingredient = usedIngredients[dishIngredientsEnumerator.Current.Key],
                    Quantity = dishIngredientsEnumerator.Current.Value
                };
                await _dishIngredients.Add(link);
                Console.WriteLine(link);
            }
            dishIngredientsEnumerator.Dispose();

            return _mapper.Map<DishDto>(createdDish);
        }
    }
}
