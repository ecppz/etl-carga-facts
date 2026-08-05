using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public StoreRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertAsync(Store store)
        {
            await _dbContext.Stores.AddAsync(store);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
