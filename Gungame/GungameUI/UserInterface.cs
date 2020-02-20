using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Gungame.GungameData;

namespace Gungame.GungameUI
{
    class UserInterface
    {
        Simulator simulator = new Simulator();
        /// <summary>
        /// Prints out the menupoints.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="list"></param>
        /// <param name="exitmessage"></param>
        public void PrintMenu(string title, string[] list, string exitmessage)
        {
            Console.WriteLine(title + $":{Environment.NewLine}");
            int counter = 0;

            foreach (string option in list)
            {
                counter++;
                Console.WriteLine(" (" + Convert.ToString(counter) + ") " + option);
            }
            Console.WriteLine(" (0) " + exitmessage);
        }

        /// <summary>
        /// Handling menu options and print it out
        /// </summary>
        public void HandleMenu()
        {
            string[] options = new string[]
            {
                    "1vs1",
                    "1vsAI",
                    "More than 2 players"
            };
            Console.WriteLine("Welcome to Gungame!\n");
            PrintMenu("Main menu", options, "Exit program");
        }

        /// <summary>
        /// Helps us get input from user and choose a menu option depends on the input
        /// </summary>
        public void Choose()
        {
            Console.WriteLine("\nPlease enter a number: ");
            string option = Console.ReadLine();
            switch (option) {
                case "1":
                    simulator.RunProgramWith1v1();
                    break;
                case "2":
                    simulator.RunProgramWithAI();
                    break;
                case "3":
                //Krisz;
                case "0":
                    TimeSpan ts = new TimeSpan(0, 0, 2);
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(ts);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input! Try again.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        /// <summary>
        /// Asks the name of the player.
        /// </summary>
        /// <returns></returns>
        public string AskPlayerName(string playerName)
        {
            Console.WriteLine($"{playerName} please tell us your name: ");
            string userinput = Console.ReadLine();
            Console.Clear();
            return userinput;
        }
        /// <summary>
        /// Prints out the hand and asks for a card which tha player wants to play, then returns it's name as string.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card2"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string AskCardFromHand(Player player, Card card2 = null, string attribute = null)
        {
            Console.Clear();
            Console.WriteLine($"{player.name}, cards in your hand:{Environment.NewLine}");

            foreach (Card card in player.hand)
            {
                Console.WriteLine(card + $"{Environment.NewLine}");
            }

            PrintChosenCardByPlayers(card2, attribute);
            Console.WriteLine("Please tell us which card you want to choose from your hand: ");
            string userinput = Console.ReadLine();
            return userinput;
        }
        /// <summary>
        /// Checks if the attribute given by the player is legit, then returns it.
        /// </summary>
        /// <returns></returns>
        public string AskAttribute()
        {
            bool ValidAttribute(string attribute)
            {
                List<string> Attributes = new List<string>() { "armorpen", "sharpness", "firerate" };
                if (Attributes.Contains(attribute))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            Console.WriteLine("Please input the attribute you want to choose: ");
            string userinput = Console.ReadLine();
            if (ValidAttribute(userinput) == true)
            {
                return userinput;
            }
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Prints out the winner of the round.
        /// </summary>
        /// <param name="winner"></param>
        public void PrintWinner(string winner)
        {
            Console.Clear();
            Console.WriteLine("The round winner is: " + winner + "!");
            Console.WriteLine("\nPress enter to start the next round.");
            Console.ReadKey();
        }
        /// <summary>
        /// Prints out the match winner
        /// </summary>
        /// <param name="player"></param>
        public void PrintGameWinner(Player player)
        {
            Console.Clear();
            Console.WriteLine("The GAME winner is: " + player.name + "! GG.");
            Console.WriteLine("\nPress enter to return the main menu.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Prints out the card played by the enemy and the chosen attribute.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="attribute"></param>
        public void PrintChosenCardByPlayers(Card card, string attribute)
        {
            if (card != null)
            {
                Console.WriteLine("\nThe chosen card by the other player is: \n");
                Console.WriteLine(card + "\n");
                Console.WriteLine("\nThe chosen attribute  is: " + attribute + "\n");
            }
        }
        /// <summary>
        /// Prints out then waits.
        /// </summary>
        public void DealingCardsPrint()
        {
            Console.Clear();
            Console.WriteLine("Shuffling the deck, and dealing cards, please wait...");
            Thread.Sleep(2400);
            Console.Clear();
        }
        /// <summary>
        /// Prints out who'll start the next round.
        /// </summary>
        /// <param name="player"></param>
        public void PrintStartingPlayer(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.name} is starting! ");
            Thread.Sleep(1500);
            Console.Clear();
        }
        /// <summary>
        /// Prints out the current stats.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public void PrintGameStatus(Player player1, Player player2)
        {
            Console.WriteLine($"\nThe current stat is:  {player1.name}: {player1.wonHands} --- {player2.name}: {player2.wonHands}\n");
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Prints out the card chosen by the ai.
        /// </summary>
        /// <param name="card"></param>
        public void PrintAIChosenCard(Card card)
        {
            if(card is KnifeCard)
            {
                Console.Clear();
                Console.WriteLine("The AI chosen the following Card: \n" + (KnifeCard)card);
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadKey();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("The AI chosen the following Card: \n" + (WeaponCard)card);
                Console.WriteLine("\nPress enter to continue.");
                Console.ReadKey();
            }
        }
    }
}
