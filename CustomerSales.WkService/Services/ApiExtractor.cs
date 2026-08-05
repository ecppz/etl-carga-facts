using System.Net.Http.Json;
using CustomerSales.Data.Entities.Db;
using CustomerSales.WkService.Interfaces;

namespace CustomerSales.WkService.Services
{
    public class ApiExtractor : IApiExtractor
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiExtractor> _logger;
        private readonly string _apiUrl;

        public ApiExtractor(HttpClient httpClient, ILogger<ApiExtractor> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiUrl = config["Sources:ApiUrl"]
                ?? throw new ArgumentNullException(nameof(config), "API URL isnot configured");
        }

        public async Task<IEnumerable<Sale>> ExtractAsync()
        {
            _logger.LogInformation("Starting API extraction from {Url}", _apiUrl);

            var sales = await _httpClient.GetFromJsonAsync<List<Sale>>(_apiUrl);

            _logger.LogInformation("API extraction completed. Records: {Count}", sales?.Count ?? 0);
            return sales ?? new List<Sale>();
        }
    }
}
