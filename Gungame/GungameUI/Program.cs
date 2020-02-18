using System;
using Gungame.GungameData;


namespace Gungame.GungameUI
{
    class Program
    {
        static void Main(string[] args)
        {

           UserInterface ui = new UserInterface();

            while (true)
            {
                ui.HandleMenu();
                try
                {
                    ui.Choose();
                }
                catch (InvalidOperationException)

                {
                    Console.WriteLine("Wrong input! Try again.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
