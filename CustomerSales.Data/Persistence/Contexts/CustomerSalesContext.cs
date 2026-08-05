using CustomerSales.Data.Entities.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerSales.Data.Persistence.Contexts
{
    public class CustomerSalesContext : DbContext
    {
        public CustomerSalesContext(DbContextOptions<CustomerSalesContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}