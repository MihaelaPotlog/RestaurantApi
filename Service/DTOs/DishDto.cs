using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTOs
{
    public class DishDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
    }
}
