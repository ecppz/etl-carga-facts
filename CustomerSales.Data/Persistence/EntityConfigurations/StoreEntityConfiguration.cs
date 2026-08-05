using CustomerSales.Data.Entities.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerSales.Data.Persistence.EntityConfigurations
{
    public class StoreEntityConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            #region Basic configuration
            builder.HasKey(s => s.StoreId);
            builder.ToTable("Stores");
            #endregion

            #region Property configurations
            builder.Property(s => s.StoreName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Location).HasMaxLength(100);
            #endregion

            #region Relationships
            builder.HasMany(s => s.Sales)
                   .WithOne(sa => sa.Store)
                   .HasForeignKey(sa => sa.StoreId);
            #endregion
        }
    }
}
