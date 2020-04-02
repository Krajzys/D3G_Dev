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
            Bridge game = new Bridge();
            game.DisplayAllHands();
        }
    }

    public class Deck
    {
        public readonly Card[] _cards;                               // <- zmieniłem prywatność

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

        public void Shuffle()                                          // <- zmieniłem prywatność
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
    
    //------------------------------------------------Zadanie-Brydż---------
    
    public class Bridge
    {
        public Player n;
        public Player s;
        public Player e;
        public Player w;
        
        public Bridge()
        {
            n = new Player();
            s = new Player();
            e = new Player();
            w = new Player();
            
            this.Deal();
        }
        
        private void Deal()
        {
            Deck bridgeDeck = new Deck();
            bridgeDeck.Shuffle();
            
            int cardsInHand = 0;
            for (int cardNumber = 0; cardNumber < 51; cardNumber += 4)
            {
                n.Hand[cardsInHand] = bridgeDeck._cards[cardNumber];
                s.Hand[cardsInHand] = bridgeDeck._cards[cardNumber + 1];
                e.Hand[cardsInHand] = bridgeDeck._cards[cardNumber + 2];
                w.Hand[cardsInHand] = bridgeDeck._cards[cardNumber + 3];
                cardsInHand++;
            }
        }
        
        public void DisplayAllHands()
        {
            Console.WriteLine("Player 'N' -----------");
            n.DisplayHand();
            Console.WriteLine("\nPlayer 'S' -----------");
            s.DisplayHand();
            Console.WriteLine("\nPlayer 'E' -----------");
            e.DisplayHand();
            Console.WriteLine("\nPlayer 'W' -----------");
            w.DisplayHand();
        }
    }
    
    public class Player
    {
        public Card[] Hand;
        
        public Player()
        {
            Hand = new Card[13];
        }
        
        public void DisplayHand()
        {
            foreach ( Card card in Hand )
            {
                string cardToDisplay = card.ToDisplay();
                Console.WriteLine(cardToDisplay);
            }
        }
    }
}