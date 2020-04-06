using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs;
using Service.DTOs.RequestDTOs;
using Service.DTOs.ResponseDto;

namespace Service
{
    public interface IOrdersService
    {
        Task<IResponseDto> CreateOrder(CreateOrderDto request);
        Task<IResponseDto> GetAll();
        IResponseDto GetAllWithinRange(DateTime startDate, DateTime endDate);
    }
}
