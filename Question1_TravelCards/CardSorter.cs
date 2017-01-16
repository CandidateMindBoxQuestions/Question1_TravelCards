using System.Collections.Generic;
using System.Linq;

namespace Question1_TravelCards
{
    public class CardSorter
    {
        //O(n)
        public List<Card> Sort(IList<Card> set)
        {
            int setCount = set.Count;
            if (setCount < 2) return new List<Card>(set);

            IList<Card> orderedSet = new List<Card>();

            Dictionary<string, Card> fromCardToCard = new Dictionary<string, Card>(setCount);
            FromCardToCardDictionaryInit(set, fromCardToCard);

            Card firstCard = GetFirstCard(set, fromCardToCard);
            orderedSet.Add(firstCard);
            
            set.Remove(firstCard);

            for (int i = 1; i < setCount; i++)
                orderedSet.Add(GetLinkCard(orderedSet[i-1], fromCardToCard));

            return (List<Card>)orderedSet;
        }

        //O(n), initialize dictionary fromCardToCard by cards in baseCards
        private void FromCardToCardDictionaryInit(IList<Card> baseCards, Dictionary<string, Card> fromCardToCard)
        {
            foreach (Card card in baseCards)
                fromCardToCard.Add(card.From, card);
        }

        //O(n), get first card of chain in set
        private Card GetFirstCard(IList<Card> set, Dictionary<string, Card> fromToCard)
        {
            HashSet<string> froms=new HashSet<string>();
            foreach (var card in set)
                froms.Add(card.From);
            foreach (var card in set)
                froms.Remove(card.To);

            return fromToCard[froms.First()];
        }

        //O(1), get the following link card for card
        private Card GetLinkCard(Card card, Dictionary<string, Card> fromToCard)
        {
            return fromToCard[card.To];
        }
    }
}
