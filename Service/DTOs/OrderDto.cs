using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Service.DTOs
{
    public class OrderDto : IEntityDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Adress Adress { get; set; }
        public IList<OrderDishDto> Dishes { get; set; }

        public class OrderDishDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}
