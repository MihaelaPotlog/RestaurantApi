using System;
using System.Collections.Generic;
using System.Text;
using Service.DTOs.RequestDTOs;
using Service.DTOs.ResponseDto;

namespace Service
{
    public interface IOrdersService
    {
        IResponseDto CreateOrder(CreateOrderDto request);
    }
}
