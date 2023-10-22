using Exchange.Enums;

namespace Exchange.Models
{
    public class Currency
    {
        public CurrencyIso Iso { get; set; }
        public decimal RateToHundredDkk { get; set; }
    }
}
