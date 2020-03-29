using System.Collections.Generic;

namespace Infrastructure.DataSeeding
{
    public class SupplierData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, double> Ingredients { get; set; }

    }
}
