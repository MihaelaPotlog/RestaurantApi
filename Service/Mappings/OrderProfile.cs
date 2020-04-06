using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Domain;
using Service.DTOs;

namespace Service.Mappings
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dto => dto.Dishes, opt =>
                    opt.MapFrom(src =>
                        src.OrderDishes.Select(orderDish => new OrderDto.OrderDishDto()
                            {
                                Id = orderDish.DishId,
                                Name = orderDish.Dish.Name,
                                Count = orderDish.Count
                            })
                        )
                    );
        }
    }
}
