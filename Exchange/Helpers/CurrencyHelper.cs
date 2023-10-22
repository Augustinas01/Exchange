using Exchange.Enums;
using Exchange.Models;

namespace Exchange.Helpers
{
    public static class CurrencyHelper
    {
        public static CurrencyIso Parse(string val)
        {
            if (Enum.TryParse<CurrencyIso>(val, out var iso))
            {
                return iso;
            }
            else
            {
                throw new FormatException("Unknown currency ISO");
            };
        }

        public static decimal GetPairExchangeRateForHundred(Currency from, Currency to)
        {
            if (from.Iso == CurrencyIso.DKK)
            {
                return to.RateToHundredDkk;
            }
            else
            {
                return (to.RateToHundredDkk / from.RateToHundredDkk) * 100;
            }
        }
    }
}
