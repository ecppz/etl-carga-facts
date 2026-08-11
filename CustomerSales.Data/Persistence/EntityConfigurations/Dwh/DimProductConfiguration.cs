using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Dwh;

namespace CustomerSales.Data.Persistence.EntityConfiguration.Dwh
{
    public class DimProductConfiguration : IEntityTypeConfiguration<DimProduct>
    {
        public void Configure(EntityTypeBuilder<DimProduct> builder)
        {
            builder.ToTable("DimProduct");
            builder.HasKey(p => p.ProductId);
        }
    }
}
