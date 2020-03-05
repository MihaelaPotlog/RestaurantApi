using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Domain.Entities;

namespace Domain
{
    public class IngredientOnStock:IBaseEntity
    {
        public Guid Id { get; private set; }
        public double Quantity { get; set; }
        public string Name { get; set; }
        public List<DishIngredient> IngredientDishes { get; set; }
        public List<IngredientSupplier> Suppliers { get; set; }

        private IngredientOnStock()
        {
        }

        public static IngredientOnStock Create(string name, double quantity)
        {
            return new IngredientOnStock()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Quantity = quantity,
                IngredientDishes = new List<DishIngredient>(),
                Suppliers =  new List<IngredientSupplier>()
            };
        }
        

    }
}
