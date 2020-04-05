namespace Service.DTOs
{
    public class IngredientDto:IEntityDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
    }
}
