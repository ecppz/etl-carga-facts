using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerSales.Data.Entities.Dwh;

namespace CustomerSales.Data.Persistence.EntityConfiguration.Dwh
{
    public class DimPaymentMethodConfiguration : IEntityTypeConfiguration<DimPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<DimPaymentMethod> builder)
        {
            builder.ToTable("DimPaymentMethod");
            builder.HasKey(p => p.PaymentId);
        }
    }
}
