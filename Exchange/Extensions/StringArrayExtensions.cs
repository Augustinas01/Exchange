using Exchange.Helpers;
using Exchange.Models;
using System.Text.RegularExpressions;

namespace Exchange.Extensions
{
    public static class StringArrayExtensions
    {
        public static ExchangeData ToExchangeAction(this string[] arr)
        {
            ExchangeData result;
            var IsoPattern = @"\b[A-Z]{3}/[A-Z]{3}\b"; // 3x UpperCase letters, on both sides of "/" sign
            var currencyPair = arr[0];
            var exchangeAmount = arr[1];

            if (Regex.IsMatch(currencyPair, IsoPattern))
            {
                var separateCurIso = currencyPair.Split('/');

                result = new()
                {
                    ExchangeFrom = CurrencyHelper.Parse(separateCurIso[1]),
                    ExchangeTo = CurrencyHelper.Parse(separateCurIso[0])
                };

            }
            else
            {
                throw new FormatException("Provided exchange pair is invalid");
            }

            result.AmmountToBuy = decimal.Parse(exchangeAmount);

            return result;
        }
    }
}
