using CustomerSales.Data.Entities.Dwh;
using CustomerSales.Data.Persistence.Contexts;
using CustomerSales.WkService.Interfaces;

namespace CustomerSales.WkService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var api = scope.ServiceProvider.GetRequiredService<IApiExtractor>();
            var dwContext = scope.ServiceProvider.GetRequiredService<CustomerSalesDWContext>();

            dwContext.DimCustomers.RemoveRange(dwContext.DimCustomers);
            dwContext.DimProducts.RemoveRange(dwContext.DimProducts);
            dwContext.DimStores.RemoveRange(dwContext.DimStores);
            dwContext.DimPaymentMethods.RemoveRange(dwContext.DimPaymentMethods);
            dwContext.FactSales.RemoveRange(dwContext.FactSales);

            await dwContext.SaveChangesAsync();

            var sales = await api.ExtractSalesAsync();
            var customers = await api.ExtractCustomersAsync();
            var products = await api.ExtractProductsAsync();
            var stores = await api.ExtractStoresAsync();
            var paymentMethods = await api.ExtractPaymentMethodsAsync();

            dwContext.DimCustomers.AddRange(customers.Select(c => new DimCustomer
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.Phone,
                Address = c.Address,
                Email = c.Email
            }));

            dwContext.DimProducts.AddRange(products.Select(p => new DimProduct
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Category = p.Category,
                Price = p.Price,
                Stock = p.Stock
            }));

            dwContext.DimStores.AddRange(stores.Select(s => new DimStore
            {
                StoreId = s.StoreId,
                StoreName = s.StoreName,
                Location = s.Location
            }));

            dwContext.DimPaymentMethods.AddRange(paymentMethods.Select(pm => new DimPaymentMethod
            {
                PaymentId = pm.PaymentId,
                MethodName = pm.MethodName
            }));

            await dwContext.SaveChangesAsync();

            dwContext.FactSales.AddRange(sales.Select(s => new FactSale
            {
                SaleId = s.SaleId,
                CustomerId = s.CustomerId,
                ProductId = s.ProductId,
                StoreId = s.StoreId,
                PaymentId = s.PaymentId,
                SaleDate = s.SaleDate,
                Quantity = s.Quantity,
                TotalAmount = s.TotalAmount
            }));

            await dwContext.SaveChangesAsync();

            _logger.LogInformation(
                "Carga completada: Sales={salesCount}, Customers={custCount}, Products={prodCount}, Stores={storeCount}, PaymentMethods={payCount}",
                sales.Count(), customers.Count(), products.Count(), stores.Count(), paymentMethods.Count());
        }
    }
}
