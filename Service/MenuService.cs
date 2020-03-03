using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Interfaces;

namespace Service
{
    public class MenuService:IService
    {
        private readonly IRepository<Dish> _dishes;
        private readonly IMapper _mapper;

        public async Task<Dish> Get(Guid id)
        {
            return await _dishes.Get(id);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dishes.Delete(id);
        }

        public async Task Update(Dish dish)
        {
            await _dishes.Update(dish);
        }

        public async Task<List<Dish>> GetAll()
        {
            return await _dishes.GetAll();
        }
    }
}
