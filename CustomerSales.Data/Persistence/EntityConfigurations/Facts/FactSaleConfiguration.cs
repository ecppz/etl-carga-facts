using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Dwh;

namespace CustomerSales.Data.Persistence.EntityConfiguration.Facts
{
    public class FactSaleConfiguration : IEntityTypeConfiguration<FactSale>
    {
        public void Configure(EntityTypeBuilder<FactSale> builder)
        {
            builder.ToTable("FactSale");
            builder.HasKey(f => f.SaleId);

            builder.HasOne(f => f.Customer)
                   .WithMany()
                   .HasForeignKey(f => f.CustomerId);

            builder.HasOne(f => f.Product)
                   .WithMany()
                   .HasForeignKey(f => f.ProductId);

            builder.HasOne(f => f.Store)
                   .WithMany()
                   .HasForeignKey(f => f.StoreId);

            builder.HasOne(f => f.PaymentMethod)
                   .WithMany()
                   .HasForeignKey(f => f.PaymentId);
        }
    }
}
