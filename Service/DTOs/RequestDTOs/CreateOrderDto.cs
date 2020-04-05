using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Service.DTOs.RequestDTOs
{
    public class CreateOrderDto
    {
        // public IDictionary<Guid, int> WantedDishes { get; set; }
        public IList<WantedDish> WantedDishes { get; set; }

        public class WantedDish
        {
            public Guid Id { get; set; }
            public int Count { get; set; }
        }
    }
}
