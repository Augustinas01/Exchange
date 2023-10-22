using Exchange.Abstractions;
using Exchange.Enums;
using Exchange.Extensions;
using Exchange.Helpers;

namespace Exchange.Services
{
    public class CommandLineService : ICliService
    {
        private readonly ExchangeService _exchangeService;

        public CommandLineService()
        {
            _exchangeService = new ExchangeService();
        }
        public string ReturnResultFromArgs(string[] args)
        {
            try
            {
                return CommandLineHelper.TryToGetUserRequest(args) switch
                {
                    RequestedAction.Exchange => _exchangeService.Exchange(args.ToExchangeAction()).ToString(),
                    RequestedAction.Unknown => "Usage: Exchange <currency pair> <amount to exhange>",
                    _ => "Program couldn't understood what you wrote :(",
                };
            }
            catch (FormatException ex)
            {
                return ex.Message;
            }
        }
    }
}
