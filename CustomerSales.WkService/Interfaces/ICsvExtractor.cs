using CustomerSales.Data.Entities.Csv;
using CustomerSales.Data.Entities.Db;

namespace CustomerSales.WkService.Interfaces
{
    public interface ICsvExtractor : IExtractorService<CsvSaleModel>
    {
    }
}
