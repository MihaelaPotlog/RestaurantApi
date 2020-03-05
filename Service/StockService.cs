using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Service.DTOs;

namespace Service
{
    public class StockService:IIngredientsService
    {
        private readonly IRepository<IngredientOnStock> _ingredientsRepository;
        private readonly IMapper _mapper;

        public StockService(IRepository<IngredientOnStock> ingredientsRepository, IMapper mapper)
        {
            _ingredientsRepository = ingredientsRepository;
            _mapper = mapper;
        }

        public Task<IngredientOnStock> Get(Guid id)
        {
            return _ingredientsRepository.Get(id);
        }
        public async Task<IList<IngredientOnStock>> GetAll()
        {
            return await _ingredientsRepository.GetAll();
        }
        public async Task<IList<IngredientOnStock>> Add(IngredientDto addIngredientDto)
        {
            if((EfCoreIngredientsRepository)_ingredientsRepository.Ge)

            IngredientOnStock newIngredient = IngredientOnStock.Create(addIngredientDto.Name, addIngredientDto.Quantity);

            // return await _ingredientsRepository.Add();
        }
    }
}
