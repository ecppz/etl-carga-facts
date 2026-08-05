using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public ProductRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
