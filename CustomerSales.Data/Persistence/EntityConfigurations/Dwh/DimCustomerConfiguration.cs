using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Dwh;

namespace CustomerSales.Data.Persistence.EntityConfiguration.Dwh
{
    public class DimCustomerConfiguration : IEntityTypeConfiguration<DimCustomer>
    {
        public void Configure(EntityTypeBuilder<DimCustomer> builder)
        {
            builder.ToTable("DimCustomer");
            builder.HasKey(c => c.CustomerId);
        }
    }

}
