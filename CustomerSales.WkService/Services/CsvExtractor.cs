using CsvHelper;
using CustomerSales.Data.Entities.Csv;
using CustomerSales.Data.Entities.Db;
using CustomerSales.WkService.Interfaces;
using System.Globalization;

namespace CustomerSales.WkService.Services
{
    public class CsvExtractor : ICsvExtractor
    {
        private readonly ILogger<CsvExtractor> _logger;
        private readonly string? _filePath;

        public CsvExtractor(ILogger<CsvExtractor> logger, IConfiguration config)
        {
            _logger = logger;
            _filePath = config["Sources:CsvPath"]; 
        }

        public async Task<IEnumerable<CsvSaleModel>> ExtractAsync()
        {
            _logger.LogInformation("Starting CSV extraction...");

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<CsvSaleModel>().ToList();

            _logger.LogInformation("CSV extraction completed. Records: {Count}", records.Count);
            return await Task.FromResult(records);
        }
    }
}
