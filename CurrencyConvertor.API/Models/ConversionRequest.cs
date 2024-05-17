namespace CurrencyConvertor.API.Models
{
    public class ConversionRequest
    {
        public decimal Amount { get; set; }
        public string? FromCurrency { get; set; }
        public string? ToCurrency { get; set; }
    }
}
