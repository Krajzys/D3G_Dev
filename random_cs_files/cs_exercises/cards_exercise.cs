using System;

/*
Zadanie 2.
Zmodyfikuj przykład z tasowaniem kart. Należy wylosować rozdanie do brydża. Mamy 4 graczy, każdy po 13 kart.
Nazywają się "N", "S", "E", "W". Niech każdy gracz wypisze swoje karty.

*/
namespace Rextester
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.DisplayShuffled();
        }
    }

    public class Deck
    {
        private readonly Card[] _cards;

        public Deck()
        {
            _cards = new Card[52];
            SetCards();
        }

        public void DisplayShuffled()
        {
            this.Shuffle();
            this.Display();
        }

        private void Shuffle()
        {
            Randomizer randomizer = new Randomizer();
            for (int index = 0; index < 52; index++)
            {
                int randomNumber = randomizer.NextValue(51);
                Card randomCard = _cards[randomNumber];
                Card firstCard = _cards[index];
                _cards[index] = randomCard;
                _cards[randomNumber] = firstCard;
            }
        }


        private void SetCards()
        {



            string[] suits = new string[] { "H", "D", "S", "C" };
            string[] values = new string[] { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };

            int counter = 0;
            foreach (string suit in suits)
            {
                foreach (string cardValue in values)
                {
                    Card card = new Card(suit, cardValue);

                    _cards[counter] = card;
                    counter++;

                }
            }
        }

        private void Display()
        {
            foreach (Card card in _cards)
            {
                string cardToDisplay = card.ToDisplay();
                Console.WriteLine(cardToDisplay);
            }

        }

    }
    public class Card
    {
        private string Suit { get; set; }
        private string Value { get; set; }

        public Card(string suit, string cardValue)
        {
            Suit = suit;
            Value = cardValue;
        }

        public string ToDisplay()
        {
            return String.Format("{0} {1}", Suit, Value);
        }
    }

    public class Randomizer
    {
        private Random _random;

        public Randomizer()
        {
            _random = new Random();
        }

        public int NextValue(int limit)
        {
            int random = _random.Next(0, limit);
            return random;
        }
    }
}