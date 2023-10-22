using Exchange.Abstractions;
using Exchange.Helpers;
using Exchange.Models;

namespace Exchange.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly DatabaseService _database;

        public ExchangeService()
        {
            _database = new();
        }

        public decimal Exchange(ExchangeData action)
        {
            var currencyFrom = _database.GetCurrency(action.ExchangeFrom);
            var currencyTo = _database.GetCurrency(action.ExchangeTo);
            var exchangeRateForHundred = CurrencyHelper.GetPairExchangeRateForHundred(currencyFrom, currencyTo);

            return (action.AmmountToBuy / 100) * exchangeRateForHundred;
        }
    }
}
