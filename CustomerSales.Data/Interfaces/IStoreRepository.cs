using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllAsync();
    }
}
