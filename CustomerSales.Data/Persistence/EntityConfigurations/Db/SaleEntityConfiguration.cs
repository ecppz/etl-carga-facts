using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Persistence.EntityConfigurations.Db
{
    public class SaleEntityConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            #region Basic configuration
            builder.HasKey(s => s.SaleId);
            builder.ToTable("Sales");
            #endregion

            #region Property configurations
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.TotalAmount).HasPrecision(10, 2);
            #endregion

            #region Relationships
            builder.HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId);

            builder.HasOne(s => s.Product)
                   .WithMany(p => p.Sales)
                   .HasForeignKey(s => s.ProductId);

            builder.HasOne(s => s.Store)
                   .WithMany(st => st.Sales)
                   .HasForeignKey(s => s.StoreId);

            builder.HasOne(s => s.PaymentMethod)
                   .WithMany(pm => pm.Sales)
                   .HasForeignKey(s => s.PaymentId);
            #endregion
        }
    }
}
