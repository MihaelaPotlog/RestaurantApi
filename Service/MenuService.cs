using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Service.DTOs;
using Service.DTOs.RequestDTOs;
using Service.DTOs.ResponseDto;

namespace Service
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unityOfWork;
       
        private readonly IMapper _mapper;


        public MenuService(IUnitOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<IResponseDto> Get(string id)
        {
            Guid.TryParse(id, out Guid dishId);
            var searchedDish = await _unityOfWork.DishesRepository.Get(dishId);

            if (searchedDish == null)
                return ErrorResponseDto.Create(ErrorMessages.IdNotFound);

            return SuccessResponseDto.Create(_mapper.Map<DishDto>(searchedDish));
        }

        public async Task<bool> Delete(string id)
        {
            Guid.TryParse(id, out Guid dishId);

            var dish = await _unityOfWork.DishesRepository.Get(dishId);
            if (dish != null)
            {
                await _unityOfWork.DishesRepository.Delete(dish);
                await _unityOfWork.CommitAsync();
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
            var dish = await _unityOfWork.DishesRepository.Get(dishId);
            dish.Name = request.Name;
            dish.Price = request.Price;
            dish.DishIngredients.Clear();


            foreach (var requestDishIngredient in request.DishIngredients)
            {
                var ingredient = await _unityOfWork.IngredientsRepository.Get(requestDishIngredient.Key);
                var link = new DishIngredient()
                {
                    Dish = dish,
                    Ingredient = ingredient,
                    Quantity = requestDishIngredient.Value
                };

                await _unityOfWork.DishIngredientsRepository.Add(link);
            }

            await _unityOfWork.DishesRepository.Update(dish);
            await _unityOfWork.CommitAsync();
        }

        public async Task<IResponseDto> GetAll()
        {
            return SuccessResponseDto.Create(_mapper.Map<IList<DishDto>>(await _unityOfWork.DishesRepository.GetAll()));
        }

        public async Task<IResponseDto> Create(CreateDishDto request)
        {
            IDictionary<Guid, IngredientOnStock> usedIngredients = new Dictionary<Guid, IngredientOnStock>();
            bool isAvailable = true;
            var dishIngredientsEnumerator = request.DishIngredients.GetEnumerator();

            while (dishIngredientsEnumerator.MoveNext() && isAvailable == true)
            {

                double quantity = dishIngredientsEnumerator.Current.Value;

                var usedIngredient = await _unityOfWork.IngredientsRepository.Get(dishIngredientsEnumerator.Current.Key);
                if (usedIngredient == null)
                    return null;

                usedIngredients.Add(usedIngredient.Id, usedIngredient);
                if (usedIngredient.Quantity < quantity)
                    isAvailable = false;

            }
            dishIngredientsEnumerator.Dispose();

            Dish createdDish = Dish.Create(request.Name, request.Price, isAvailable);
            var id = createdDish.Id;
            await _unityOfWork.DishesRepository.Add(createdDish);

            dishIngredientsEnumerator = request.DishIngredients.GetEnumerator();
            while (dishIngredientsEnumerator.MoveNext())
            {
                DishIngredient link = new DishIngredient()
                {
                    Dish = createdDish,
                    Ingredient = usedIngredients[dishIngredientsEnumerator.Current.Key],
                    Quantity = dishIngredientsEnumerator.Current.Value
                };
                await _unityOfWork.DishIngredientsRepository.Add(link);
                Console.WriteLine(link);
            }
            dishIngredientsEnumerator.Dispose();

            await _unityOfWork.CommitAsync();

            var dishDto = _mapper.Map<DishDto>(createdDish);
            return SuccessResponseDto.Create(dishDto);
        }
    }
}
