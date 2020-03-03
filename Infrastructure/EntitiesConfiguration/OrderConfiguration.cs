using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration
{
    class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(order => order.Adress).Property(adress => adress.City).IsRequired();
            builder.OwnsOne(order => order.Adress).Property(adress => adress.Street).IsRequired();

        }
    }
}
