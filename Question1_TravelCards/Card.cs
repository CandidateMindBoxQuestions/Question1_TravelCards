namespace Question1_TravelCards
{
    public class Card
    {
        public string From { get; set; }
        public string To { get; set; }

        public Card(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
