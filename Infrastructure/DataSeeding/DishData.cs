using System.Collections.Generic;

namespace Infrastructure.DataSeeding
{
    public class DishData
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Dictionary<string, double> UsedIngredients { get; set; }
    }
}
