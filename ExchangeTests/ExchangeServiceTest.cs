using Exchange.Enums;
using Exchange.Models;
using Exchange.Services;

namespace ExchangeTests
{
    internal class ExchangeServiceTest
    {
        private ExchangeService _exchangeService;
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

            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(7.4394m));
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

            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(1m/7.4394m));
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

            // Act
            decimal result = _exchangeService.Exchange(data);

            // Assert
            Assert.That(result, Is.EqualTo(0.8913487646853240852756942764m));
        }
    }
}
