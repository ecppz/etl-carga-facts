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
            // db
            var dbConn = config.GetConnectionString("DBConnection");

            services.AddDbContext<CustomerSalesContext>(opt =>
                opt.UseSqlServer(dbConn,
                m => m.MigrationsAssembly(typeof(CustomerSalesContext).Assembly.FullName)),
                ServiceLifetime.Scoped);

            var dwConn = config.GetConnectionString("DWConnection");
            
            // dw
            services.AddDbContext<CustomerSalesDWContext>(opt =>
                opt.UseSqlServer(dwConn,
                m => m.MigrationsAssembly(typeof(CustomerSalesDWContext).Assembly.FullName)),
                ServiceLifetime.Scoped);

            services.AddScoped(typeof(IExtractorService<>), typeof(ExtractionService<>));
            services.AddScoped<ICsvExtractor, CsvExtractor>();
            services.AddScoped<IDatabaseExtractor, DatabaseExtractor>();
            services.AddHttpClient<ApiExtractor>();
            services.AddScoped<IApiExtractor, ApiExtractor>();
        }
    }

}
