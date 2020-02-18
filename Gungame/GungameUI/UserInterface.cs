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
        public void PrintMenu(string title, string[] list, string exitmessage)
        {

            Console.WriteLine (title + $":{Environment.NewLine}");
            int counter = 0;

            foreach (string option in list)
            {
                counter++;
                Console.WriteLine (" (" + Convert.ToString(counter) + ") " + option);
            }

            Console.WriteLine (" (0) " + exitmessage);
        }

        /// <summary>
        /// Handling menu options nad print it out
        /// </summary>
        public void HandleMenu()
        {
            
            string[] options = new string[]
            {
                    "1vs1",
                    "1vsAI",
                   
            };

            PrintMenu("Main menu", options, "Exit program");
        }

        /// <summary>
        /// Helps us get input from user and choose a menu option depends on the input
        /// </summary>
       public void Choose()
        {

            Console.WriteLine ("\nPlease enter a number: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                simulator.RunProgramWith1v1();
            }
            else if (option == "2")
            {
                //simulator.RunProgramWithAI();
            }
            else if (option == "0")
            {
               
                TimeSpan ts = new TimeSpan(0, 0, 2);
                Console.WriteLine("Exiting...");
                Thread.Sleep(ts);
 
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong input! Try again.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }


        public  string AskPlayerName()
        {
            Console.WriteLine("Player1, please tell us your name: ");
            string userinput = Console.ReadLine();
            Console.Clear();
            return userinput;
        }

        public  string AskPlayer2Name()
        {
            Console.WriteLine("Player2, please tell us your name: ");
            string userinput = Console.ReadLine();
            Console.Clear();
            return userinput;
        }


        public   string AskCardFromHand(Player player)
        {
            Console.Clear();
            Console.WriteLine($"{player.name}, cards in your hand:{Environment.NewLine}");

            foreach (Card card in player.hand)
            {
                Console.WriteLine(card+$"{Environment.NewLine}");
            }

            Console.WriteLine("Please tell us which card you want to choose from your hand: ");
            string userinput = Console.ReadLine();
            return userinput;

        }
        public  string AskAttribute()
        {
            Console.WriteLine("Please input the attribute you want to choose: ");
            string userinput = Console.ReadLine();
            return userinput;
        }

        public  void PrintWinner(string winner)
        {
            Console.Clear();
            Console.WriteLine("The round winner is: " + winner + "!");
            Console.WriteLine("\nPress enter to start the next round.");
            Console.ReadKey();
        }


        public void PrintGameWinner(Player player)
        {
            Console.Clear();
            Console.WriteLine("The GAME winner is: " + player.name + "! GG.");
            Console.WriteLine("\nPress enter to return the main menu.");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
