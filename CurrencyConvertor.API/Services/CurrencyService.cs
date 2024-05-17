using CurrencyConvertor.API.Helpers;
using CurrencyConvertor.API.Models;

namespace CurrencyConvertor.API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CurrencyRate> GetLatestRatesAsync(string baseCurrency)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await RetryPolicy.ExecuteAsync(() => client.GetAsync($"https://api.frankfurter.app/latest?base={baseCurrency}"));

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CurrencyRate>();
        }

        public async Task<decimal?> ConvertCurrencyAsync(ConversionRequest request)
        {
            var forbiddenCurrencies = new[] { "TRY", "PLN", "THB", "MXN" };
            if (forbiddenCurrencies.Contains(request.FromCurrency) || forbiddenCurrencies.Contains(request.ToCurrency))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient();//https://api.frankfurter.app/current?from=USD&
            var response = await RetryPolicy.ExecuteAsync(() => client.GetAsync($"https://api.frankfurter.app/latest?base={request.FromCurrency}&"));

            response.EnsureSuccessStatusCode();          

            var rates = await response.Content.ReadFromJsonAsync<CurrencyRate>();
            if (rates != null && rates.Rates != null)
            {
                var rate = rates.Rates.FirstOrDefault(r => r.Key == request.ToCurrency).Value;
                return rate != 0 ? rate * request.Amount : (decimal?)null;
            }
            return null;
        }

        public async Task<IEnumerable<CurrencyRate>> GetHistoricalRatesAsync(string baseCurrency, DateTime startDate, DateTime endDate, int page, int pageSize)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await RetryPolicy.ExecuteAsync(() => client.GetAsync($"https://api.frankfurter.app/{startDate:yyyy-MM-dd}..{endDate:yyyy-MM-dd}?base={baseCurrency}"));

            response.EnsureSuccessStatusCode();
            var rates = await response.Content.ReadFromJsonAsync<Dictionary<string, Dictionary<string, decimal>>>();
            return rates
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new CurrencyRate
                {
                    Date = DateTime.Parse(r.Key),
                    Base = baseCurrency,
                    Rates = r.Value
                });
        }
    }

}
