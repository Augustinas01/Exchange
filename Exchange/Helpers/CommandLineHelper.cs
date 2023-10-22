using Exchange.Enums;

namespace Exchange.Helpers
{
    internal static class CommandLineHelper
    {
        internal static RequestedAction TryToGetUserRequest(string[] args)
        {
            return args.Length != 2 ? RequestedAction.Unknown : RequestedAction.Exchange;
        }

    }
}
