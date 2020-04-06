namespace Domain.Entities
{
    public class Adress
    {
        public string City { get; set; }
        public string Street { get; set; }

        private Adress()
        {

        }
        public static Adress Create(string city, string street)
        {
            return new Adress()
            {
                City = city,
                Street = street
            };
        }
    }
}
