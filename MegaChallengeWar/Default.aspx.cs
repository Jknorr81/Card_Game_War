using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            // header "Dealing cards...."

            resultLabel.Text = "<h2>Dealing Cards</h2><br />";

            // Create deck of cards using Card and Deck classes

            // display deal, show player and card given

            Game game = new Game("James", "Willy");

            resultLabel.Text += game.Play();

            // header "Begin Battle"

            resultLabel.Text += "<h2>Begin Battle...</h2><br />";

            // display each round: players card vs players card, bounty, winner
            // if war, go through war()

            resultLabel.Text += game.Battle();

            // display winner
        }
    }
}