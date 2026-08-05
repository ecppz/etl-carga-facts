using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> InsertAsync(Product product);
    }
}
