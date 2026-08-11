using CustomerSales.Data.Entities.Db;

namespace CustomerSales.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
