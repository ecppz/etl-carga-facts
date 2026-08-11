using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public StoreRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await _dbContext.Stores.ToListAsync();
        }
    }
}
