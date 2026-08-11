using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public CustomerRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
