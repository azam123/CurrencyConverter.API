using CurrencyConvertor.API.Models;
using CurrencyConvertor.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConvertor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("latest/{baseCurrency}")]
        public async Task<IActionResult> GetLatestRates(string baseCurrency)
        {
            var rates = await _currencyService.GetLatestRatesAsync(baseCurrency);
            return Ok(rates);
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] ConversionRequest request)
        {
            var result = await _currencyService.ConvertCurrencyAsync(request);
            if (result == null)
            {
                return BadRequest("Conversion not allowed for specified currencies.");
            }

            return Ok(new { result });
        }

        [HttpGet("historical/{baseCurrency}")]
        public async Task<IActionResult> GetHistoricalRates(string baseCurrency, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var rates = await _currencyService.GetHistoricalRatesAsync(baseCurrency, startDate, endDate, page, pageSize);
            return Ok(rates);
        }
    }
}
