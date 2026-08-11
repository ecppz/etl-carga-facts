using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Application.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
    }
}
