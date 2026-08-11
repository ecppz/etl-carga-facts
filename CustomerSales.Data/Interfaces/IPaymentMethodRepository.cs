using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetAllAsync();
    }
}
