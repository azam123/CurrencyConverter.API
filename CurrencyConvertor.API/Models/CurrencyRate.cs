namespace CurrencyConvertor.API.Models
{
    public class CurrencyRate
    {
        public decimal Amount { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }

}
