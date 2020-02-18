using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using Gungame.GungameUI;

namespace Gungame.GungameData
{
    class RoundSimulator
    {
        public void SimulateRound(Player player1, Player player2,CardHandler deck)
        {
            string nameOfCard;
            Card player1Card;
            Card player2Card;
            
            
            player1Card = deck.GetCardByName(player1.hand, UserInterface.AskCardFromHand(player1));

            string attribute;
            
            if (player1.wonBefore == true)
            {
                attribute = UserInterface.AskAttribute();
                player2Card = deck.GetCardByName(player2.hand, UserInterface.AskCardFromHand(player2));
                Table round = new Table(player1Card, player2Card);
                round.GetWinner(player1,player2,attribute);
            }
            else
            {

            }
        }
        public void RunProgramWith1v1()
        {
            CardHandler cardHandler = new CardHandler();
            CSVHandler csvHandler = new CSVHandler();
            csvHandler.CsvHandler("Cards.csv");
            cardHandler.deck = csvHandler.listOfCards;
            string playerName = UserInterface.AskPlayerName();
            Player player1 = new Player(playerName, cardHandler.Dealer());
            player1.wonBefore = true;
            playerName = UserInterface.AskPlayerName();
            Player player2 = new Player(playerName, cardHandler.Dealer());

        }
    }
}
