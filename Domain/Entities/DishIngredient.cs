using System;
using Domain.Entities;

namespace Domain
{
    public class DishIngredient:IBaseEntity
    {
        public Guid DishId { get; set; }
        public Guid IngredientId { get; set; }
        public double Quantity { get; set; }

        public Dish Dish { get; set; }
        public IngredientOnStock Ingredient { get; set; }

    }
}
