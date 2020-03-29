using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class Dish:IBaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public List<OrderDish> DishOrders { get; set; }
        public List<DishIngredient> DishIngredients { get; set; }

        private Dish()
        {

        }

        public static Dish Create(string name, double price, bool isAvailable)
        {
            return new Dish()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                IsAvailable = isAvailable,
                DishOrders = new List<OrderDish>(),
                DishIngredients = new List<DishIngredient>()
            };
        }



    }
}
