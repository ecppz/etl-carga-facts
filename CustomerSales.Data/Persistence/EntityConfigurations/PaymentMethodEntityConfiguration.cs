using CustomerSales.Data.Entities.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerSales.Data.Persistence.EntityConfigurations
{
    public class PaymentMethodEntityConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            #region Basic configuration
            builder.HasKey(pm => pm.PaymentId);
            builder.ToTable("PaymentMethods");
            #endregion

            #region Property configurations
            builder.Property(pm => pm.MethodName).IsRequired().HasMaxLength(50);
            #endregion

            #region Relationships
            builder.HasMany(pm => pm.Sales)
                   .WithOne(s => s.PaymentMethod)
                   .HasForeignKey(s => s.PaymentId);
            #endregion
        }
    }
}
