using CustomerSales.Application.Interfaces;
using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly CustomerSalesContext context;

        public PaymentMethodService(CustomerSalesContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await context.PaymentMethods.ToListAsync();
        }
    }
}
