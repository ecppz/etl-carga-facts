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
            services.AddScoped<ISaleService, SaleService>();
        }
    }
}
