using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
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
        public IResponseDto CreateOrder(CreateOrderDto request)
        {
            // cauta dishurile orderului
               //verifica daca sunt available
            // create order
            // scade din fiecare ingredient folosit in dishurile alese
            //si pentru fiecare ingredient modificat se verifica dishurile la care se foloseste ingredientul (is available?)
            return null;
        }

        // ***
        public IResponseDto GetAll()
        {
            return null;
        }

        //***
        public IResponseDto GetAllWithinRange(DateTime startDate, DateTime endDate)
        {
            return null;
        }

    }
}
