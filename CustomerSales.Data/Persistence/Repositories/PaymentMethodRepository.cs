using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public PaymentMethodRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertAsync(PaymentMethod paymentMethod)
        {
            await _dbContext.PaymentMethods.AddAsync(paymentMethod);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
