using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain
{
    public class Supplier:IBaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<IngredientSupplier> SupplierIngredients { get; set; }

        private Supplier()
        {

        }
        public Supplier(string firstname, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = FirstName;
            LastName = lastName;
            SupplierIngredients = new List<IngredientSupplier>();

        }
    }
}
