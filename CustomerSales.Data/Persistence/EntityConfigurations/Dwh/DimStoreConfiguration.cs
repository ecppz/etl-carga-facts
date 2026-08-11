using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Dwh;

namespace CustomerSales.Data.Persistence.EntityConfiguration.Dwh
{
    public class DimStoreConfiguration : IEntityTypeConfiguration<DimStore>
    {
        public void Configure(EntityTypeBuilder<DimStore> builder)
        {
            builder.ToTable("DimStore");
            builder.HasKey(s => s.StoreId);
        }
    }

}
