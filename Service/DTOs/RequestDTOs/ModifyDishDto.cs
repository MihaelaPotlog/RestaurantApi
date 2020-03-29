using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTOs.RequestDTOs
{
    public class ModifyDishDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Dictionary<Guid, double> DishIngredients { get; set; }
    }
}
