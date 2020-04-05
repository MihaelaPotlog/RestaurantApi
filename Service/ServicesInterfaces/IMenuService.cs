using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Service.DTOs;
using Service.DTOs.RequestDTOs;
using Service.DTOs.ResponseDto;

namespace Service
{
    public interface IMenuService
    {
        Task<IResponseDto> Get(string id);
        Task<bool> Delete(string id);
        Task<IResponseDto> Create(CreateDishDto request);
        Task Modify(string id, ModifyDishDto dish);
        Task Replace(string id, ModifyDishDto request);
        Task<IResponseDto> GetAll();
    }
}
