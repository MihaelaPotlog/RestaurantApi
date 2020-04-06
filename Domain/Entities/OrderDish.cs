using System;
using System.Dynamic;
using System.Threading;

namespace Domain.Entities
{
    public class OrderDish : IBaseEntity
    {
        public Guid DishId { get; set; }
        public Guid OrderId { get; set; }

        public Dish Dish { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }

        private OrderDish()
        {

        }

        public static OrderDish Create(Dish dish, Order order, int count)
        {
            return new OrderDish()
            {
                Dish = dish,
                Order = order,
                Count = count
            };
        }
    }
}
