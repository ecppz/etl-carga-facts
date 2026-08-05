using CustomerSales.Application.Interfaces;
using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;

namespace CustomerSales.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository repo;

        public SaleService(ISaleRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync()
        {
            return await repo.GetAllAsync();
        }
    }
}
