using CustomerSales.Data.Entities.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CustomerSales.Data.Persistence.EntityConfigurations.Db
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region Basic configuration
            builder.HasKey(p => p.ProductId);
            builder.ToTable("Products");
            #endregion

            #region Property configurations
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Category).HasMaxLength(50);
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Stock);
            #endregion

            #region Relationships
            builder.HasMany(p => p.Sales)
                   .WithOne(s => s.Product)
                   .HasForeignKey(s => s.ProductId);
            #endregion
        }
    }
}
