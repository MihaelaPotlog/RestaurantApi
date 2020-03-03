using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderDish
    {
        public Guid DishId { get; set; }
        public Guid OrderId { get; set; }

        public Dish Dish { get; set; }
        public Order Order { get; set; }
    }
}
