using CurrencyConvertor.API.Models;

namespace CurrencyConvertor.API.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyRate> GetLatestRatesAsync(string baseCurrency);
        Task<decimal?> ConvertCurrencyAsync(ConversionRequest request);
        Task<IEnumerable<CurrencyRate>> GetHistoricalRatesAsync(string baseCurrency, DateTime startDate, DateTime endDate, int page, int pageSize);
    }
}
