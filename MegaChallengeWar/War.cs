using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class War
    {
        public string result;
        private List<Card> _warBounty;
        private Card ply1WarCard;
        private Card ply2WarCard;

        public string war( Player _player1, Player _player2, List<Card> _bounty)
        {
            result += "<br /><h4>*********WAR********</h4>";
            result += displayWarCards(_player1, _player1);
            getWarBounty(_player1, _player1, _bounty);
            result += displayWarBounty(_warBounty);
            performEvaluation(_player1, _player2, ply1WarCard, ply2WarCard);     
            return result;
        }
        private Card getNextCard(Player player)
        {
            Card card = player.Cards.First();
            player.Cards.Remove(card);
            return card;
        }
        private string displayWarBounty(List<Card> _warBounty)
        {
            string warBounty = "<br/>War bounty cards:";
            foreach (var card in _warBounty)
            {
                warBounty += string.Format("<br />&nbsp;&nbsp;&nbsp;{0} of {1}", card.DisplayName, card.Suit);
            }
            return warBounty;
        }
        private void performEvaluation(Player player1, Player player2, Card ply1WarCard, Card ply2WarCard)
        {
            if (ply1WarCard.CardValue > ply2WarCard.CardValue) awardWinner(player1);
            else if (ply1WarCard.CardValue < ply2WarCard.CardValue) awardWinner(player2);
            else if (_warBounty.Count == 0) return;
            else war(player1,player2,_warBounty);
        }
        private string awardWinner(Player player)
        {
            player.Cards.AddRange(_warBounty);
            _warBounty.Clear();
            result += string.Format("<br /><h4>{0} Wins!!!</h4>", player.PlayerName);
            return result;
        }
        private List<Card> getWarBounty(Player player1, Player player2, List<Card> bounty)
        {
            _warBounty = new List<Card> { getNextCard(player1), getNextCard(player1),
            getNextCard(player2),getNextCard(player2)};
            _warBounty.AddRange(bounty);
            _warBounty.Add(ply1WarCard);
            _warBounty.Add(ply2WarCard);
            return _warBounty;
        }
        private Card getWarCard(Player player)
        {
            Card warCard = getNextCard(player);
            return warCard;
        }
        private string displayWarCards(Player player1, Player player2)
        {
            string warCards = "";
            ply1WarCard = getWarCard(player1);
            ply2WarCard = getWarCard(player2);
            warCards += string.Format("War Battle Cards: {0} of {1} VERSUS {2} of {3}",
                ply1WarCard.DisplayName, ply1WarCard.Suit,
                ply2WarCard.DisplayName, ply2WarCard.Suit);
            return warCards;
        }
    }
}