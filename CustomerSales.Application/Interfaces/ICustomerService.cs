using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
