namespace CustomerSales.WkService.Interfaces
{
    public interface IExtractorService<T>
    {
        Task<IEnumerable<T>> ExtractAsync();
    }
}
