using AutoMapper;
using Domain;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Mappings
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>()
                .ForMember(dest => dest.Ingredients, opt =>
                    opt.MapFrom(src => src.DishIngredients.Select(dishIngredient =>
                         new KeyValuePair<string, double>(dishIngredient.Ingredient.Name, dishIngredient.Quantity))
                        .ToDictionary(item =>item.Key, item=> item.Value)));
        }
    }
}
