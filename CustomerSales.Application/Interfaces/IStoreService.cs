using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Application.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetStoresAsync();
    }
}
