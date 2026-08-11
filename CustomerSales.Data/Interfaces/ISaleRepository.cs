using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
    }
}
