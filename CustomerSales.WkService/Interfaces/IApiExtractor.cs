using CustomerSales.Data.Entities.Db;

namespace CustomerSales.WkService.Interfaces
{
    public interface IApiExtractor 
    {
        Task<IEnumerable<Sale>> ExtractSalesAsync();
        Task<IEnumerable<Customer>> ExtractCustomersAsync();
        Task<IEnumerable<Product>> ExtractProductsAsync();
        Task<IEnumerable<Store>> ExtractStoresAsync();
        Task<IEnumerable<PaymentMethod>> ExtractPaymentMethodsAsync();
    }
}
