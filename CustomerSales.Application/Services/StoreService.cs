using CustomerSales.Application.Interfaces;
using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly CustomerSalesContext context;

        public StoreService(CustomerSalesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            return await context.Stores.ToListAsync();
        }
    }
}
