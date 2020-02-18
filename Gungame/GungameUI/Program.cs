using System;
using Gungame.GungameData;


namespace Gungame
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
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
=======
           
>>>>>>> Stashed changes
        }
    }
}
