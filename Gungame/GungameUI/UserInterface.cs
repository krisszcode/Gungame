using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameUI
{
    class UserInterface
    {
        
      RoundSimulator simulator = new RoundSimulator();
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
                simulator.RunProgramWithAI();
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

    }
}
