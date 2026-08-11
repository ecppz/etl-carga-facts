using CustomerSales.Data.Entities.Dwh;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerSales.Data.Persistence.Contexts
{
    public class CustomerSalesDWContext : DbContext
    {
        public CustomerSalesDWContext(DbContextOptions<CustomerSalesDWContext> options) : base(options) { }
        public DbSet<DimCustomer> DimCustomers { get; set; }
        public DbSet<DimProduct> DimProducts { get; set; }
        public DbSet<DimStore> DimStores { get; set; }
        public DbSet<DimPaymentMethod> DimPaymentMethods { get; set; }
        public DbSet<FactSale> FactSales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}