using CurrencyConvertor.API.Models;
using CurrencyConvertor.API.Services;
using Moq;

namespace CurrencyConvertor.API.Tests
{
    public class CurrencyServiceTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly CurrencyService _currencyService;

        public CurrencyServiceTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _currencyService = new CurrencyService(_httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task GetLatestRatesAsync_ShouldReturnRates()
        {
            // Arrange
            var httpClient = new HttpClient(new MockHttpMessageHandler());
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var rates = await _currencyService.GetLatestRatesAsync("EUR");

            // Assert
            Assert.NotNull(rates);
            Assert.Equal("EUR", rates.Base);
        }

        [Fact]
        public async Task ConvertCurrencyAsync_ShouldReturnConvertedAmount()
        {
            // Arrange
            var httpClient = new HttpClient(new MockHttpMessageHandler());
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
            var request = new ConversionRequest { Amount = 100, FromCurrency = "USD", ToCurrency = "EUR" };

            // Act
            var result = await _currencyService.ConvertCurrencyAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result > 0);
        }

        [Fact]
        public async Task ConvertCurrencyAsync_ShouldReturnBadRequestForForbiddenCurrencies()
        {
            // Arrange
            var request = new ConversionRequest { Amount = 100, FromCurrency = "TRY", ToCurrency = "EUR" };

            // Act
            var result = await _currencyService.ConvertCurrencyAsync(request);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetHistoricalRatesAsync_ShouldReturnRates()
        {
            // Arrange
            var httpClient = new HttpClient(new MockHttpMessageHandler());
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            // Act
            var rates = await _currencyService.GetHistoricalRatesAsync("EUR", new DateTime(2020, 1, 1), new DateTime(2020, 1, 31), 1, 10);

            // Assert
            Assert.NotNull(rates);
            Assert.True(rates.Any());
        }
    }
}