using CustomerSales.Data.Entities.Db;
using CustomerSales.WkService.Interfaces;
using System.Net.Http.Json;

public class ApiExtractor : IApiExtractor
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiExtractor> _logger;
    private readonly string _baseUrl;

    public ApiExtractor(HttpClient httpClient, ILogger<ApiExtractor> logger, IConfiguration config)
    {
        _httpClient = httpClient;
        _logger = logger;
        _baseUrl = config["Sources:ApiBaseUrl"]
            ?? throw new ArgumentNullException(nameof(config), "API Base URL is not configured");
    }

    public async Task<IEnumerable<Sale>> ExtractSalesAsync()
    {
        var url = $"{_baseUrl}/Sale";
        return await _httpClient.GetFromJsonAsync<List<Sale>>(url) ?? new List<Sale>();
    }

    public async Task<IEnumerable<Customer>> ExtractCustomersAsync()
    {
        var url = $"{_baseUrl}/Customer";
        return await _httpClient.GetFromJsonAsync<List<Customer>>(url) ?? new List<Customer>();
    }

    public async Task<IEnumerable<Product>> ExtractProductsAsync()
    {
        var url = $"{_baseUrl}/Product";
        return await _httpClient.GetFromJsonAsync<List<Product>>(url) ?? new List<Product>();
    }

    public async Task<IEnumerable<Store>> ExtractStoresAsync()
    {
        var url = $"{_baseUrl}/Store";
        return await _httpClient.GetFromJsonAsync<List<Store>>(url) ?? new List<Store>();
    }

    public async Task<IEnumerable<PaymentMethod>> ExtractPaymentMethodsAsync()
    {
        var url = $"{_baseUrl}/PaymentMethod";
        return await _httpClient.GetFromJsonAsync<List<PaymentMethod>>(url) ?? new List<PaymentMethod>();
    }
}
