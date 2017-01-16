using System;
using NUnit.Framework;
using Moq;

namespace Question1_TravelCards.Tests
{
    [TestFixture]
    public class CardTests
    {
        private Card _card;

        [OneTimeSetUp]
        public void Initialize()
        {
            _card = new Card("from", "to");
        }

        [Test]
        public void Constructor_works_correctly()
        {
            Assert.That((_card.From == "from") && (_card.To == "to"));
        }
    }
}
