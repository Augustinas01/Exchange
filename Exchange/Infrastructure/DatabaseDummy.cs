using Exchange.Enums;
using Exchange.Models;

namespace Exchange.Infrastructure
{
    internal class DatabaseDummy
    {
        private readonly HashSet<Currency> _currencies = new()
        {
            new Currency { Iso = CurrencyIso.DKK, RateToHundredDkk = 100m},
            new Currency { Iso = CurrencyIso.EUR, RateToHundredDkk = 743.94m},
            new Currency { Iso = CurrencyIso.USD, RateToHundredDkk = 663.11m},
            new Currency { Iso = CurrencyIso.GBP, RateToHundredDkk = 852.85m},
            new Currency { Iso = CurrencyIso.SEK, RateToHundredDkk = 76.10m},
            new Currency { Iso = CurrencyIso.NOK, RateToHundredDkk = 78.40m},
            new Currency { Iso = CurrencyIso.CHF, RateToHundredDkk = 683.58m},
            new Currency { Iso = CurrencyIso.JPY, RateToHundredDkk = 5.9740m},
        };

        public Currency GetCurrencyByIso(CurrencyIso iso)
        {
            return _currencies.First(c => c.Iso == iso);
        }
    }
}
