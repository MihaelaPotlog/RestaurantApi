using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Entities;
using Service.DTOs;
using Service.DTOs.RequestDTOs;
using Service.DTOs.ResponseDto;

namespace Service
{
    public class OrdersService : IOrdersService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // ***
        public async Task<IResponseDto> CreateOrder(CreateOrderDto request)
        {
            bool areAllAvailable = true;
            var wantedDishesEnumerator = request.WantedDishes.GetEnumerator();
            IList<Dish> wantedDishes = new List<Dish>();
            IDictionary<Guid, int> wantedDishesCount = new Dictionary<Guid, int>();

            while (wantedDishesEnumerator.MoveNext() && areAllAvailable == true)
            {

                var wantedDish = await _unitOfWork.DishesRepository.Get(wantedDishesEnumerator.Current.Id);
                wantedDishes.Add(wantedDish);
                wantedDishesCount.Add(wantedDish.Id, wantedDishesEnumerator.Current.Count);

                areAllAvailable = wantedDish.IsAvailable;
            }
            wantedDishesEnumerator.Dispose();

            if (areAllAvailable == false)
                return ErrorResponseDto.Create("Some dishes are not available.");
            var createdOrder = Order.Create(DateTime.Now, request.Adress);
            await _unitOfWork.OrdersRepository.Add(createdOrder);

            foreach (var wantedDish in wantedDishes)
            {
                wantedDishesCount.TryGetValue(wantedDish.Id, out int count);
                var orderDish = OrderDish.Create(wantedDish, createdOrder, count);

                await _unitOfWork.OrderDishesRepository.Add(orderDish);
                foreach (var wantedDishIngredient in wantedDish.DishIngredients)
                {
                    IngredientOnStock usedIngredient = wantedDishIngredient.Ingredient;
                    usedIngredient.Quantity -= wantedDishIngredient.Quantity;
                    await _unitOfWork.IngredientsRepository.Update(wantedDishIngredient.Ingredient);
                    foreach (var usedIngredientDish in wantedDishIngredient.Ingredient.IngredientDishes)
                    {
                        if (usedIngredientDish.Quantity > wantedDishIngredient.Ingredient.Quantity)
                        {
                            usedIngredientDish.Dish.IsAvailable = false;
                            await _unitOfWork.DishesRepository.Update(usedIngredientDish.Dish);
                        }
                    }
                }
            }

            await _unitOfWork.CommitAsync();

            // cauta dishurile orderului
            //verifica daca sunt available
            // create order
            // scade din fiecare ingredient folosit in dishurile alese
            //si pentru fiecare ingredient modificat se verifica dishurile la care se foloseste ingredientul (is available?)
            return SuccessResponseDto.Create(_mapper.Map<OrderDto>(createdOrder));
        }

        // ***
        public async Task<IResponseDto> GetAll()
        {
            var allOrders = await _unitOfWork.OrdersRepository.GetAll();
            return SuccessResponseDto.Create(_mapper.Map<List<OrderDto>>(allOrders));
        }

        //***
        public  IResponseDto GetAllWithinRange(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine(startDate);
            Func<Order, bool> condition = (order) => order.Date.CompareTo(startDate) >= 0 && order.Date.CompareTo(endDate) <= 0;
            var orders = _unitOfWork.OrdersRepository.FindAll(condition);
            return SuccessResponseDto.Create(_mapper.Map<List<OrderDto>>(orders));
        }

    }
}
