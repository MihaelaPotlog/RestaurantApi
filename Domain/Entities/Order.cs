using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class Order : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Adress Adress { get; set; }
        public List<OrderDish> OrderDishes { get; set; }

        private Order()
        {

        }

        public static Order Create(DateTime date, Adress adress)
        {
            return new Order()
            {
                Id = Guid.NewGuid(),
                Date = date,
                Adress = adress,
                OrderDishes = new List<OrderDish>()
            };
        }
    }
}
