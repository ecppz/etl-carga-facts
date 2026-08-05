using CustomerSales.Data.Entities.Db;
namespace CustomerSales.Application.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetSalesAsync();
    }
}