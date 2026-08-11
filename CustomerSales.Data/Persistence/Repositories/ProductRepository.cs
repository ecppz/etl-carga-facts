using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public ProductRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
