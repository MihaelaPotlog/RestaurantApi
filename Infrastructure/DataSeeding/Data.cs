using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataSeeding
{
    public class Data
    {
        public Dictionary<string, double> IngredientsOnStock { get; set; }
        public List<DishData> Dishes { get; set; }
        public List<OrderData> Orders { get; set; }
        public List<SupplierData> Suppliers { get; set; }
    }
}
