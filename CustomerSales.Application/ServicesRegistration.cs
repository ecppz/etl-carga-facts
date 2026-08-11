using CustomerSales.Application.Interfaces;
using CustomerSales.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerSales.Application
{
    public static class ServicesRegistration
    {
        public static void ApplicationLayerIoc(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<ISaleService, SaleService>();
        }
    }
}
