using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck
    {
        private List<Card> _deckOfCards;
        private Random _random;
        private StringBuilder _sb;

        // creating the deck of cards

        public Deck()
        {
          

            _random = new Random();
            _sb = new StringBuilder();

            /*string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    _deckOfCards.Add(new Card() { Suit = suit, Kind = kind });
                }
            }*/


            _deckOfCards = new List<Card>()
              { new Card() { CardValue = 2, Suit = "Clubs", DisplayName = "2" } ,
                new Card() { CardValue = 3, Suit = "Clubs", DisplayName = "3" } ,
                new Card() { CardValue = 4, Suit = "Clubs", DisplayName = "4" } ,
                new Card() { CardValue = 5, Suit = "Clubs", DisplayName = "5" } ,
                new Card() { CardValue = 6, Suit = "Clubs", DisplayName = "6" } ,
                new Card() { CardValue = 7, Suit = "Clubs", DisplayName = "7" } ,
                new Card() { CardValue = 8, Suit = "Clubs", DisplayName = "8" } ,
                new Card() { CardValue = 9, Suit = "Clubs", DisplayName = "9" } ,
                new Card() { CardValue = 10, Suit = "Clubs", DisplayName = "10" },
                new Card() { CardValue = 11, Suit = "Clubs", DisplayName = "Jack" },
                new Card() { CardValue = 12, Suit = "Clubs", DisplayName = "Queen" },
                new Card() { CardValue = 13, Suit = "Clubs", DisplayName = "King" },
                new Card() { CardValue = 14, Suit = "Clubs", DisplayName = "Ace" },
                new Card() { CardValue = 2, Suit = "Spades", DisplayName = "2" },
                new Card() { CardValue = 3, Suit = "Spades", DisplayName = "3" },
                new Card() { CardValue = 4, Suit = "Spades", DisplayName = "4" },
                new Card() { CardValue = 5, Suit = "Spades", DisplayName = "5" },
                new Card() { CardValue = 6, Suit = "Spades", DisplayName = "6" },
                new Card() { CardValue = 7, Suit = "Spades", DisplayName = "7" },
                new Card() { CardValue = 8, Suit = "Spades", DisplayName = "8" },
                new Card() { CardValue = 9, Suit = "Spades", DisplayName = "9" },
                new Card() { CardValue = 10, Suit = "Spades", DisplayName = "10" },
                new Card() { CardValue = 11, Suit = "Spades", DisplayName = "Jack" },
                new Card() { CardValue = 12, Suit = "Spades", DisplayName = "Queen" },
                new Card() { CardValue = 13, Suit = "Spades", DisplayName = "King" },
                new Card() { CardValue = 14, Suit = "Spades", DisplayName = "Ace" },
                new Card() { CardValue = 2, Suit = "Diamonds", DisplayName = "2" },
                new Card() { CardValue = 3, Suit = "Diamonds", DisplayName = "3" },
                new Card() { CardValue = 4, Suit = "Diamonds", DisplayName = "4" },
                new Card() { CardValue = 5, Suit = "Diamonds", DisplayName = "5" },
                new Card() { CardValue = 6, Suit = "Diamonds", DisplayName = "6" },
                new Card() { CardValue = 7, Suit = "Diamonds", DisplayName = "7" },
                new Card() { CardValue = 8, Suit = "Diamonds", DisplayName = "8" },
                new Card() { CardValue = 9, Suit = "Diamonds", DisplayName = "9" },
                new Card() { CardValue = 10, Suit = "Diamonds", DisplayName = "10" },
                new Card() { CardValue = 11, Suit = "Diamonds", DisplayName = "Jack" },
                new Card() { CardValue = 12, Suit = "Diamonds", DisplayName = "Queen" },
                new Card() { CardValue = 13, Suit = "Diamonds", DisplayName = "King" },
                new Card() { CardValue = 14, Suit = "Diamonds", DisplayName = "Ace" },
                new Card() { CardValue = 2, Suit = "Hearts", DisplayName = "2" },
                new Card() { CardValue = 3, Suit = "Hearts", DisplayName = "3" },
                new Card() { CardValue = 4, Suit = "Hearts", DisplayName = "4" },
                new Card() { CardValue = 5, Suit = "Hearts", DisplayName = "5" },
                new Card() { CardValue = 6, Suit = "Hearts", DisplayName = "6" },
                new Card() { CardValue = 7, Suit = "Hearts", DisplayName = "7" },
                new Card() { CardValue = 8, Suit = "Hearts", DisplayName = "8" },
                new Card() { CardValue = 9, Suit = "Hearts", DisplayName = "9" },
                new Card() { CardValue = 10, Suit = "Hearts", DisplayName = "10" },
                new Card() { CardValue = 11, Suit = "Hearts", DisplayName = "Jack" },
                new Card() { CardValue = 12, Suit = "Hearts", DisplayName = "Queen" },
                new Card() { CardValue = 13, Suit = "Hearts", DisplayName = "King" },
                new Card() { CardValue = 14, Suit = "Hearts", DisplayName = "Ace" }
            }; 
        }

        // Dealing out the cards to players

        public string Deal(Player player1, Player player2)
        {
            while (_deckOfCards.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        private void dealCard(Player player)
        {
            Card card = _deckOfCards.ElementAt(_random.Next(_deckOfCards.Count));
            player.Cards.Add(card);
            _deckOfCards.Remove(card);

            _sb.Append("<br />");
            _sb.Append(player.PlayerName);
            _sb.Append(" is dealt the ");
            _sb.Append(card.DisplayName);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
        }
    }
}