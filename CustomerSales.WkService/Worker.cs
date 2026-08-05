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
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var csv = scope.ServiceProvider.GetRequiredService<ICsvExtractor>();
                var db = scope.ServiceProvider.GetRequiredService<IDatabaseExtractor>();
                var api = scope.ServiceProvider.GetRequiredService<IApiExtractor>();

                var csvData = await csv.ExtractAsync();
                var dbData = await db.ExtractAsync();
                var apiData = await api.ExtractAsync();

                _logger.LogInformation("Cycle completed. CSV:{csvCount}, DB:{dbCount}, API:{apiCount}",
                    csvData.Count(), dbData.Count(), apiData.Count());

                await Task.Delay(10000, stoppingToken);
            }
        }
    }

}
