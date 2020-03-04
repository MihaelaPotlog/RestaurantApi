using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Domain
{
    public class DishIngredient
    {
        public Guid DishId { get; set; }
        public Guid IngredientId { get; set; }
        public double Quantity { get; set; }

        public Dish Dish { get; set; }
        public IngredientOnStock Ingredient { get; set; }

    }
}
