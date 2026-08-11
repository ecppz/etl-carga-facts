using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
