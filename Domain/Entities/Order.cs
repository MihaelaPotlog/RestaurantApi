using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain
{
    public class Order:IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Adress Adress { get; set; }
        public List<OrderDish> OrderDishes { get; set; }

        public Order()
        {
            
        }
        public Order( DateTime date, Adress adress)
        {
            Id = Guid.NewGuid();
            Date = date;
            Adress = adress;
            OrderDishes = new List<OrderDish>();
        }
    }
}
