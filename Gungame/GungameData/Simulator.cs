using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using Gungame.GungameUI;
using System.Threading;

namespace Gungame.GungameData
{
    class Simulator
    {
        public Player GetWinner(Player player1, Player player2)
        {
            if (player1.wonHands < player2.wonHands)
            {
                return player2;
            }
            else if (player1.wonHands > player2.wonHands)
            {
                return player1;
            }
            throw new InvalidOperationException("szar");
        }


        public void SimulateRound(Player player1, Player player2, CardHandler deck)
        {
            UserInterface ui = new UserInterface();
            string nameOfCard;
            Card player1Card;
            Card player2Card;
            string attribute;
            string winnerName;
            if (player1.wonBefore == true)
            {
                while (true)
                {
                    try
                    {
                        player1Card = deck.GetCardByName(player1.hand, ui.AskCardFromHand(player1));
                        attribute = ui.AskAttribute();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrong input, please try again...\n");
                        Thread.Sleep(1500);
                        continue;
                    }
                }
                while (true)
                {
                    try
                    {
                        player2Card = deck.GetCardByName(player2.hand, ui.AskCardFromHand(player2, player1Card, attribute));
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrong input, please try again...\n");
                        Thread.Sleep(1500);
                        continue;
                    }
                }
                Table round = new Table(player1Card, player2Card);
                winnerName = round.GetRoundWinner(player1, player2, attribute).name;
                deck.RoundEndDeal(player1Card, player1);
                deck.RoundEndDeal(player2Card, player2);
            }
            else
            {
                while (true)
                {
                    try
                    {

                        player2Card = deck.GetCardByName(player2.hand, ui.AskCardFromHand(player2));
                        attribute = ui.AskAttribute();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrong input, please try again...\n");
                        TimeSpan span = new TimeSpan();
                        Thread.Sleep(1500);
                        continue;
                    }
                }
                while (true)
                {
                    try
                    {
                        player1Card = deck.GetCardByName(player1.hand, ui.AskCardFromHand(player1, player2Card, attribute));
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrong input, please try again...\n");
                        Thread.Sleep(1500);
                        continue;
                    }
                }
                Table round = new Table(player1Card, player2Card);
                winnerName = round.GetRoundWinner(player1, player2, attribute).name;
                deck.RoundEndDeal(player1Card, player1);
                deck.RoundEndDeal(player2Card, player2);
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
            Player player1 = new Player(playerName, cardHandler.FirstHandDealer());
            player1.wonBefore = true;
            string player2Name = ui.AskPlayer2Name();
            Player player2 = new Player(player2Name, cardHandler.FirstHandDealer());

            int Index = 0;
            // Index < 3
            while (player1.hand.Count > 0 && player2.hand.Count > 0 && cardHandler.deck.Count > 0)
            {
                SimulateRound(player1, player2, cardHandler);
                Index++;
            }
            ui.PrintGameWinner(GetWinner(player1, player2));
        }

        public void SimulateRoundWithAI()
        {
        }

        public void RunProgramWithAI()
        {
        }


    }
}
