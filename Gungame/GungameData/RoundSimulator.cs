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
            UserInterface ui = new UserInterface();
            string nameOfCard;
            Card player1Card;
            Card player2Card;
            
            
            

            string attribute;
            string winnerName;
            if (player1.wonBefore == true)
            {
                player1Card = deck.GetCardByName(player1.hand, ui.AskCardFromHand(player1));
                attribute = ui.AskAttribute();
                player2Card = deck.GetCardByName(player2.hand, ui.AskCardFromHand(player2));
                Table round = new Table(player1Card, player2Card);
                winnerName = round.GetWinner(player1,player2,attribute).name;

               // player1.hand = round.RemoveUsedCardAfterRound(player1, player1Card);
               // player2.hand = round.RemoveUsedCardAfterRound(player2, player2Card);    ket fele verzioval probaltam, mind a ketto errorozik
                // round.RemoveUsedCardAfterRound(player2, player2Card);

            }
            else
            {
                player2Card = deck.GetCardByName(player2.hand, ui.AskCardFromHand(player2));
                attribute = ui.AskAttribute();
                player1Card = deck.GetCardByName(player1.hand, ui.AskCardFromHand(player1));
                Table round = new Table(player1Card, player2Card);
                winnerName = round.GetWinner(player1, player2, attribute).name;
               
                //round.RemoveUsedCardAfterRound(player1, player1Card);
                //round.RemoveUsedCardAfterRound(player2, player2Card);

            }
            if (winnerName == player1.name)
            {
                player1.wonBefore = true;
                player1.wonHands++;
                player2.wonBefore = false;
            }
            else
            {
                player2.wonBefore = true;
                player2.wonHands++;
                player1.wonBefore = false;
            }

            ui.PrintWinner(winnerName);

        }
        public void RunProgramWith1v1()
        {
            UserInterface ui = new UserInterface();
            Console.Clear();
            CardHandler cardHandler = new CardHandler();
            CSVHandler csvHandler = new CSVHandler();
            csvHandler.CsvHandler("Cards.csv");
            cardHandler.deck = csvHandler.listOfCards;
            string playerName = ui.AskPlayerName();
            Player player1 = new Player(playerName, cardHandler.Dealer());
            player1.wonBefore = true;
            string player2Name = ui.AskPlayer2Name();
            Player player2 = new Player(player2Name, cardHandler.Dealer());
            for (int i = 0; i < 5; i++)
            {
                SimulateRound(player1, player2, cardHandler);
            }
            
            
        }
    }
}
