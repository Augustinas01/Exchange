using Exchange.Enums;
using Exchange.Models;
using Exchange.Services;
using System;

namespace ExchangeTests
{
    internal class ExchangeServiceTest
    {
        private ExchangeService _exchangeService;

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


        [SetUp]
        public void Setup()
        {
            _exchangeService = new ExchangeService();
        }

        [Test]
        public void SameCurrencyReturnsEqual()
        {
            // Arrange
            ExchangeData dkk = new() 
            { 
                ExchangeFrom = CurrencyIso.DKK,
                ExchangeTo = CurrencyIso.DKK,
                AmmountToBuy = 1m
            };
            ExchangeData usd = new()
            {
                ExchangeFrom = CurrencyIso.USD,
                ExchangeTo = CurrencyIso.USD,
                AmmountToBuy = 1m
            };

            // Act
            decimal dkkResult = _exchangeService.Exchange(dkk);
            decimal usdResult = _exchangeService.Exchange(usd);

            // Assert
            Assert.That(dkkResult, Is.EqualTo(1m));
            Assert.That(usdResult, Is.EqualTo(1m));
        }

        [Test]
        public void ExchangeDKKTo()
        {
            // Arrange
            ExchangeData data = new()
            {
                ExchangeFrom = CurrencyIso.DKK,
                ExchangeTo = CurrencyIso.EUR,
                AmmountToBuy = 1m
            };

            var expected = data.AmmountToBuy * (GetCurrencyByIso(data.ExchangeTo).RateToHundredDkk / GetCurrencyByIso(data.ExchangeFrom).RateToHundredDkk);

            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ExchangeToDKK()
        {
            // Arrange
            ExchangeData data = new()
            {
                ExchangeFrom = CurrencyIso.EUR,
                ExchangeTo = CurrencyIso.DKK,
                AmmountToBuy = 1m
            };

            var expected = data.AmmountToBuy * (GetCurrencyByIso(data.ExchangeTo).RateToHundredDkk / GetCurrencyByIso(data.ExchangeFrom).RateToHundredDkk);

            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ExchangeWithoutDKK()
        {
            // Arrange
            ExchangeData data = new()
            {
                ExchangeFrom = CurrencyIso.EUR,
                ExchangeTo = CurrencyIso.USD,
                AmmountToBuy = 1m
            };
            var expected = data.AmmountToBuy * (GetCurrencyByIso(data.ExchangeTo).RateToHundredDkk / GetCurrencyByIso(data.ExchangeFrom).RateToHundredDkk);
            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        private Currency GetCurrencyByIso(CurrencyIso iso)
        {
            return _currencies.First(c => c.Iso == iso);
        }
    }
}
