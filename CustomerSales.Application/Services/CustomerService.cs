using CustomerSales.Application.Interfaces;
using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerSalesContext context;

        public CustomerService(CustomerSalesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }
    }
}
