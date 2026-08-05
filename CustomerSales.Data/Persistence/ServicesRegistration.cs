using CustomerSales.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CustomerSales.Data.Persistence.Repositories;
using CustomerSales.Data.Persistence.Contexts;

namespace CustomerSales.Data.Persistence
{
    public static class ServicesRegistration
    {
        public static void PersistenceLayerIoc(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<CustomerSalesContext>(opt =>
                opt.UseSqlServer(connectionString,
                m => m.MigrationsAssembly(typeof(CustomerSalesContext).Assembly.FullName)),
                ServiceLifetime.Scoped);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
        }
    }
}
