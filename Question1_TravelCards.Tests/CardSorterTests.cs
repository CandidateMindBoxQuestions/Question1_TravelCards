using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Question1_TravelCards.Tests
{
    [TestFixture]
    public class CardSorterTests
    {
        private CardSorter _sorter;

        [OneTimeSetUp]
        public void Initialize()
        {
            _sorter=new CardSorter();
        }

        [Test]
        public void Sort_empty_collenction_is_sorted_collection()
        {
            //Arrange
            var set = new List<Card>();

            //act
            IList<Card> orderedSet = _sorter.Sort(set);

            //assert
            Assert.That(IsSorted(orderedSet));
        }

        [Test]
        public void Sort_collenction_with_1_item_is_sorted_collection()
        {
            //Arrange
            var set = new List<Card>()
            {
                new Card("Мельбурн", "Кельн")
            };

            //act
            IList<Card> orderedSet = _sorter.Sort(set);

            //assert
            Assert.That(IsSorted(orderedSet));
        }

        [Test]
        public void Sort_sorted_collenction_should_stay_sorted()
        {
            //Arrange
            var set = new List<Card>()
            {
                new Card("Мельбурн", "Кельн"),
                new Card("Кельн", "Москва"),
                new Card("Москва", "Париж")
            };

            //act
            IList<Card> orderedSet = _sorter.Sort(set);

            //assert
            Assert.That(IsSorted(orderedSet));
        }

        [Test]
        public void Sort_unordered_collection_should_be_sorted()
        {
            //Arrange
            var set = new List<Card>()
            {
                new Card("Рим", "Сараево"),
                new Card("Кельн", "Москва"),
                new Card("Веллингтон", "Рим"),
                new Card("Тунис", "Гавана"),
                new Card("Мельбурн", "Кельн"),
                new Card("Гавана", "Сан-Хосе"),
                new Card("Рига", "Багдад"),
                new Card("Москва", "Париж"),
                new Card("Токио", "Тунис"),
                new Card("Сан-Хосе", "Веллингтон"),
                new Card("Париж", "Рига"),
                new Card("Багдад", "Токио")
            };

            //act
            IList<Card> orderedSet = _sorter.Sort(set);

            //assert
            Assert.That(IsSorted(orderedSet));
        }

        //set sorting rule
        private static bool IsSorted(IList<Card> set)
        {
            bool isSorted = true;

            if (set.Count < 2) return isSorted;

            Card currentCard = set[0];

            for (int i = 1; i < set.Count; i++)
            {
                if (currentCard.To != set[i].From)
                {
                    isSorted = false;
                    break;
                }
                currentCard = set[i];
            }
            return isSorted;
        }
    }
}
