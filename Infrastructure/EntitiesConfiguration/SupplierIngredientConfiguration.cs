using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    class SupplierIngredientConfiguration : IEntityTypeConfiguration<IngredientSupplier>
    {
        public void Configure(EntityTypeBuilder<IngredientSupplier> builder)
        {
            builder.HasKey(supplierIngredient => new
            {
                supplierIngredient.SupplierId,
                supplierIngredient.IngredientId
            });
        }
    }
}
