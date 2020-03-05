using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain
{
    public class IngredientSupplier:IBaseEntity
    {
        public Guid SupplierId { get; set; }
        public Guid IngredientId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public Supplier Supplier { get; set; }
        public IngredientOnStock IngredientOnStock { get; set; }


    }
}
