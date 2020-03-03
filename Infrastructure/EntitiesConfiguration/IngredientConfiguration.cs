using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    class IngredientConfiguration:IEntityTypeConfiguration<IngredientOnStock>
    {
        public void Configure(EntityTypeBuilder<IngredientOnStock> builder)
        {
            builder.Property(ingredient => ingredient.Name).IsRequired();
            builder.Property(ingredient => ingredient.Quantity).IsRequired();
        }
    }
}
