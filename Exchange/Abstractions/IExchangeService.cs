using Exchange.Models;

namespace Exchange.Abstractions
{
    internal interface IExchangeService
    {
        decimal Exchange(ExchangeData action);
    }
}
