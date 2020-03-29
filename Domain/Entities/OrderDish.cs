using System;

namespace Domain.Entities
{
    public class OrderDish:IBaseEntity
    {
        public Guid DishId { get; set; }
        public Guid OrderId { get; set; }

        public Dish Dish { get; set; }
        public Order Order { get; set; }
    }
}
