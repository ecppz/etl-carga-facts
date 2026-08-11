using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public PaymentMethodRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
        {
            return await _dbContext.PaymentMethods.ToListAsync();
        }
    }
}
