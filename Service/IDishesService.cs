using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Service.DTOs;
using Service.DTOs.RequestDTOs;

namespace Service
{
    public interface IDishesService
    {
        Task<Dish> Get(string id);
        Task<bool> Delete(string id);
        Task<DishDto> Create(CreateDishDto request);
        Task Modify(string id, ModifyDishDto dish);
        Task Replace(string id, ModifyDishDto request);
        Task<List<DishDto>> GetAll();
    }
}
