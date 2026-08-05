using CustomerSales.Data.Persistence.Contexts;
using CustomerSales.WkService.Extractors;
using CustomerSales.WkService.Interfaces;
using CustomerSales.WkService.Services;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.WkService
{
    public static class ServicesRegistration
    {
        public static void WorkerLayerIoc(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<CustomerSalesContext>(opt =>
                opt.UseSqlServer(connectionString,
                m => m.MigrationsAssembly(typeof(CustomerSalesContext).Assembly.FullName)),
                ServiceLifetime.Scoped);

            services.AddScoped(typeof(IExtractorService<>), typeof(ExtractionService<>));
            services.AddScoped<ICsvExtractor, CsvExtractor>();
            services.AddScoped<IDatabaseExtractor, DatabaseExtractor>();
            services.AddHttpClient<ApiExtractor>();
            services.AddScoped<IApiExtractor, ApiExtractor>();
        }
    }
}
