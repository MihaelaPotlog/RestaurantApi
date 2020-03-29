namespace Domain.Entities
{
    public class Adress
    {
        public string City { get; set; }
        public string Street { get; set; }

        
        public Adress(string city, string street)
        {
            City = city;
            Street = street;
        }
    }
}
