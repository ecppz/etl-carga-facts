using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public CustomerRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
