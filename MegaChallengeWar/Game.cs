using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        public List<Card> _bounty;

        private Card _player1BattleCard;
        private Card _player2BattleCard;

        public string result;

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { PlayerName = player1Name };
            _player2 = new Player() { PlayerName = player2Name };
        }


        public string Play()
        {
            Deck deck = new Deck();
            return deck.Deal(_player1, _player2);
        }

        public string Battle()
        {
            int round = 0;
            while (_player1.Cards.Count > 0 && _player2.Cards.Count > 0)
            {
                _player1BattleCard = getNextCard(_player1);
                _player2BattleCard = getNextCard(_player2);
                _bounty = new List<Card>() { _player1BattleCard, _player2BattleCard };
                result += displayBattleCards() + displayBattleBounty();
                performEvaluation(_player1, _player2, _player1BattleCard, _player2BattleCard);               
                round++;
                if (round > 20) break;                       
            }
            result += displayWinner(_player1, _player2);

            return result;
        }
        private Card getNextCard (Player player)
        {
            Card card = player.Cards.First();
            player.Cards.Remove(card);    
            return card;
        }
        private void performEvaluation(Player player1, Player Player2, Card player1BattleCard, Card player2BattleCard)
        {
            if (player1BattleCard.CardValue > player2BattleCard.CardValue)
            {
                awardWinner(_player1);
            }
            else if (player1BattleCard.CardValue < player2BattleCard.CardValue)
            {
                awardWinner(_player2);
            }
            else if (player1BattleCard.CardValue == player2BattleCard.CardValue)
            {
                War war = new War();
                result += war.war(_player1, _player2, _bounty);
            }
        }
        private string awardWinner(Player player)
        {
            player.Cards.AddRange(_bounty);
            _bounty.Clear();
            result += string.Format("<br /><h4>{0} Wins!!!</h4>", player.PlayerName);
            return result;
        }

        private string displayBattleBounty()
        {
            string currentBattleBounty = "";
            currentBattleBounty += string.Format("<br />Bounty...<br />{0} of {1}<br />{2} of {3}",
                _player1BattleCard.DisplayName,
                _player1BattleCard.Suit,
                _player2BattleCard.DisplayName,
                _player2BattleCard.Suit);

            return currentBattleBounty;
        }

        private string displayBattleCards()
        {
            string currentBattleCards = "";

            currentBattleCards += string.Format("<br />Battle Cards: {0} of {1} VERSUS {2} of {3}",
                _player1BattleCard.DisplayName, _player1BattleCard.Suit,
                _player2BattleCard.DisplayName, _player2BattleCard.Suit);

            return currentBattleCards;
        }

        private string displayWinner(Player _player1, Player _player2)
        {
            result += string.Format("<br /><br />{0} has {1} cards", _player1.PlayerName, _player1.Cards.Count);
            result += string.Format("<br />{0} has {1} cards", _player2.PlayerName, _player2.Cards.Count);

            if (_player1.Cards.Count > _player2.Cards.Count)
            {
                result += string.Format("<br /><h4>{0} Wins the WAR!!!!!!!</h4>", _player1.PlayerName);
            }
            else
            {
                result += string.Format("<br /><h4>{0} Wins the WAR!!!!!!</h4>", _player2.PlayerName);
            }
            return result;
        }
    }
}