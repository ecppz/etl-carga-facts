using CustomerSales.Application.Interfaces;
using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly CustomerSalesContext context;

        public ProductService(CustomerSalesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
    }
}
