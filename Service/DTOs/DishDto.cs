using System;
using System.Collections.Generic;

namespace Service.DTOs
{
    public class DishDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public Dictionary<string, int> Ingredients { get; set; }
    }
}
