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

        public void Shuffle()
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

        public Card GetCardFromDeck(int index)
        {
            return _cards[index];
        }

        public int GetCardsLength()
        {
            return _cards.Length;
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
    
    //------------------------------------------------Basic-Bridge-Game---------
    
    public class Bridge
    {
        public Player[] players;

        public Bridge()
        {
            players = new Player[4] {new Player("N"), new Player("S"), new Player("E"), new Player("W")};
            this.Deal();
        }
        
        private void Deal()
        {
            Deck bridgeDeck = new Deck();
            bridgeDeck.Shuffle();

            int iterations = 0;
            while (iterations < bridgeDeck.GetCardsLength())
            {
                foreach (Player player in players)
                {
                    Card card = bridgeDeck.GetCardFromDeck(iterations);
                    player.AddCard(card);
                    iterations++;
                }
            }
        }
        
        public void DisplayAllHands()
        {
            foreach (Player player in players)
            {
                player.DisplayHand();
            }
        }
    }
    
    public class Player
    {
        private Card[] Hand {get; set;}
        private int _cardIndex;
        private string Name {get; set;} 
        
        public Player(string name)
        {
            Name = name;
            Hand = new Card[13];
            _cardIndex = 0;
        }
        
        public void AddCard(Card card)
        {
            if (_cardIndex > Hand.Length - 1)
            {
                Console.WriteLine("Gracz nie pomieści tylu kart");
                return;
            }
            if (card == null)
            {
                Console.WriteLine("Nie można dodać pustej karty");
                return;
            }
            
            Hand[_cardIndex] = card;
            _cardIndex++;
        }
        
        public void DisplayHand()
        {
            Console.WriteLine("Cards of player {0}:", Name);
            foreach ( Card card in Hand )
            {
                string cardToDisplay = card.ToDisplay();
                Console.WriteLine(cardToDisplay);
            }
            Console.WriteLine();
        }
    }
}