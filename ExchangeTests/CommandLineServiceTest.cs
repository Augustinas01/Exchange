using Exchange.Services;

namespace ExchangeTests
{
    internal class CommandLineServiceTest
    {
        private CommandLineService _cliService;

        private readonly string BadIsoMessage = "Provided exchange pair is invalid";
        private readonly string BadAmountMessage = "Input string was not in a correct format.";
        private readonly string UnknownIsoMessage = "Unknown currency ISO";

        [SetUp]
        public void Setup()
        {
            _cliService = new CommandLineService();
        }

        [Test]
        public void SameCurrencyReturnsEqual()
        {
            // Arrange
            string[] args = new string[] { "USD/USD", "1"};

            // Act
            string result = _cliService.ReturnResultFromArgs(args);

            // Assert
            Assert.That(result, Is.EqualTo("1.00"));
        }

        [Test]
        public void BadIsoFormatProvided()
        {
            // Arrange
            string[] args = new string[] { "USD/USDa", "1" };

            // Act
            string result = _cliService.ReturnResultFromArgs(args);

            // Assert
            Assert.That(result, Is.EqualTo(BadIsoMessage));
        }

        [Test]
        public void BadAmmountFormatProvided()
        {
            // Arrange
            string[] args = new string[] { "USD/USD", "1a" };

            // Act
            string result = _cliService.ReturnResultFromArgs(args);

            // Assert
            Assert.That(result, Is.EqualTo(BadAmountMessage));
        }

        [Test]
        public void UnknownIsoProvided()
        {
            // Arrange
            string[] args = new string[] { "USD/LOL", "1" };

            // Act
            string result = _cliService.ReturnResultFromArgs(args);

            // Assert
            Assert.That(result, Is.EqualTo(UnknownIsoMessage));
        }
    }
}
