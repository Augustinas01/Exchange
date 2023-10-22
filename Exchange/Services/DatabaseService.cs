using Exchange.Enums;
using Exchange.Infrastructure;
using Exchange.Models;

namespace Exchange.Services
{
    internal class DatabaseService
    {
        public Currency GetCurrency(CurrencyIso iso)
        {
            DatabaseDummy db = new();
            return db.GetCurrencyByIso(iso);
        }
    }
}
