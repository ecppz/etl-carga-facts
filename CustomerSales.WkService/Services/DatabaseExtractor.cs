using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Persistence.Contexts;
using CustomerSales.WkService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.WkService.Extractors
{
    public class DatabaseExtractor : IDatabaseExtractor
    {
        private readonly CustomerSalesContext _db;
        private readonly ILogger<DatabaseExtractor> _logger;

        public DatabaseExtractor(CustomerSalesContext db, ILogger<DatabaseExtractor> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IEnumerable<Sale>> ExtractAsync()
        {
            _logger.LogInformation("Starting DB extraction...");
            var sales = await _db.Sales
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Store)
                .Include(s => s.PaymentMethod)
                .ToListAsync();

            _logger.LogInformation("DB extraction completed. Records: {Count}", sales.Count);
            return sales;
        }
    }
}
