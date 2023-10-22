using Exchange.Enums;

namespace Exchange.Models
{
    public class ExchangeData
    {
        public CurrencyIso ExchangeFrom;
        public CurrencyIso ExchangeTo;
        public decimal AmmountToBuy;
    }
}
