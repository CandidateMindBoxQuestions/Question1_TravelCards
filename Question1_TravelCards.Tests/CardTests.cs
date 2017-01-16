using NUnit.Framework;

namespace Question1_TravelCards.Tests
{
    [TestFixture]
    public class CardTests
    {
        private Card _card;

        [OneTimeSetUp]
        public void Initialize()
        {
            //arrange
            _card = new Card("from", "to");
        }

        [Test]
        public void Constructor_works_correctly()
        {
            //assert
            Assert.That((_card.From == "from") && (_card.To == "to"));
        }
    }
}
