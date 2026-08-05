using CustomerSales.WkService.Interfaces;
using System.Text.Json;

namespace CustomerSales.WkService.Services
{
    public class ExtractionService<T>
    {
        private readonly IExtractorService<T> _extractor;
        private readonly ILogger<ExtractionService<T>> _logger;

        public ExtractionService(IExtractorService<T> extractor, ILogger<ExtractionService<T>> logger)
        {
            _extractor = extractor;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> RunAsync()
        {
            _logger.LogInformation("Running extraction for {Type}", typeof(T).Name);
            var data = await _extractor.ExtractAsync();

            var fileName = $"staging_{typeof(T).Name}_{DateTime.Now:yyyyMMddHHmmss}.json";
            await File.WriteAllTextAsync(fileName, JsonSerializer.Serialize(data));

            _logger.LogInformation("Extraction completed. Data saved to {File}", fileName);
            return data;
        }
    }
}
