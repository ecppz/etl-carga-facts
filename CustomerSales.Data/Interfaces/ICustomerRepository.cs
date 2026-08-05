using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> InsertAsync(Customer customer);
    }
}
