using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using Gungame.GungameUI;
using System.Threading;

namespace Gungame.GungameData
{
    class Simulator
    {/// <summary>
    /// Returns the player who won the most rounds.
    /// </summary>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    /// <returns></returns>
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
        /// <summary>
        /// Simulates one round of the game.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="deck"></param>
        public void SimulateRound(Player player1, Player player2, CardHandler deck)
        {
            UserInterface ui = new UserInterface();
            Card player1Card;
            Card player2Card;
            string attribute;
            string winnerName;
            if (player1.wonBefore == true)
            { 
                
                ui.PrintStartingPlayer(player1);
                ui.PrintGameStatus(player1, player2);
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
                //Puts the played cards in the table object
                Table round = new Table(player1Card, player2Card);
                winnerName = round.GetRoundWinner(player1, player2, attribute).name;
                deck.RoundEndDeal(player1Card, player1);
                deck.RoundEndDeal(player2Card, player2);
            }
            else
            {
                ui.PrintStartingPlayer(player2);
                ui.PrintGameStatus(player1, player2);
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
        /// <summary>
        /// Runs a whole match between to players.
        /// </summary>
        public void RunProgramWith1v1()
        {
            UserInterface ui = new UserInterface();
            Console.Clear();
            CardHandler cardHandler = new CardHandler();
            CSVHandler csvHandler = new CSVHandler();
            csvHandler.CsvHandler("Cards.csv");
            //Puts the cards read out from the csv to the deck 
            cardHandler.deck = csvHandler.listOfCards;
            string playerName = ui.AskPlayerName("Player 1");
            Player player1 = new Player(playerName, cardHandler.FirstHandDealer());
            player1.wonBefore = true;
            string player2Name = ui.AskPlayerName("Player 2");
            Player player2 = new Player(player2Name, cardHandler.FirstHandDealer());
            ui.DealingCardsPrint();

            int Index = 0;
            
            while (player1.hand.Count > 0 && player2.hand.Count > 0)
            {
                SimulateRound(player1, player2, cardHandler);
                Index++;
            }
            ui.PrintGameWinner(GetWinner(player1, player2));
        }


        /****
        AI starts here
        ****/
        /// <summary>
        /// Plays one round against the computer.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="ai"></param>
        /// <param name="deck"></param>
        public void SimulateRoundWithAI(Player player1, AI ai, CardHandler deck)
        {
            //This is for debug purposes
            Console.WriteLine("DEBUG: AI handje: \n");
            foreach (Card card in ai.hand)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();
            //until this point

            UserInterface ui = new UserInterface();
            Card player1Card;
            Card aiCard;
            string attribute;
            string winnerName;
            //Gets the player who won the last round so that player will start the round.
            if (player1.wonBefore == true)
            {
                ui.PrintStartingPlayer(player1);
                ui.PrintGameStatus(player1, ai);

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
                
                aiCard = ai.ChooseTheRightCardForAI(player1Card, attribute);
                ui.PrintAIChosenCard(aiCard);
              
                Table round = new Table(player1Card, aiCard);
                winnerName = round.GetRoundWinner(player1, ai, attribute).name;
                deck.RoundEndDeal(player1Card, player1);
                deck.RoundEndDeal(aiCard, ai);
            }
            else
            {
                ui.PrintStartingPlayer(ai);
                ui.PrintGameStatus(player1, ai);
                
                aiCard = ai.ChooseCardToPlay();
                attribute = ai.ReturnBestAttribute(aiCard);
                
                while (true)
                {
                    try
                    {
                        player1Card = deck.GetCardByName(player1.hand, ui.AskCardFromHand(player1, aiCard, attribute));
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nWrong input, please try again...\n");
                        Thread.Sleep(1500);
                        continue;
                    }
                }
                Table round = new Table(player1Card, aiCard);
                winnerName = round.GetRoundWinner(player1, ai, attribute).name;
                deck.RoundEndDeal(player1Card, player1);
                deck.RoundEndDeal(aiCard, ai);
            }
            
            if (winnerName == player1.name)
            {
                player1.wonBefore = true;
                player1.wonHands++;
                ai.wonBefore = false;
            }
            else
            {
                ai.wonBefore = true;
                ai.wonHands++;
                player1.wonBefore = false;
            }

            ui.PrintWinner(winnerName);
        }
        /// <summary>
        /// Runs a whole match against the computer.
        /// </summary>
        public void RunProgramWithAI()
        {
            UserInterface ui = new UserInterface();
            Console.Clear();
            CardHandler cardHandler = new CardHandler();
            CSVHandler csvHandler = new CSVHandler();
            csvHandler.CsvHandler("Cards.csv");
            cardHandler.deck = csvHandler.listOfCards;
            string playerName = ui.AskPlayerName("Player 1");
            Player player1 = new Player(playerName, cardHandler.FirstHandDealer());
            //Sets player1's wonBefore to true , so he will start the first round
            player1.wonBefore = true;
 
            AI ai = new AI(cardHandler.FirstHandDealer());
            ui.DealingCardsPrint();

            int Index = 0;
            while (player1.hand.Count > 0 && ai.hand.Count > 0)
            {
                SimulateRoundWithAI(player1, ai, cardHandler);
                Index++;
            }
            ui.PrintGameWinner(GetWinner(player1, ai));

        }


    }
}
