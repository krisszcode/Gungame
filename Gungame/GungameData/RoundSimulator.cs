using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;

namespace Gungame.GungameData
{
    class RoundSimulator
    {
        public void SimulateRound(Player player1, Player player2,CardHandler deck)
        {
            string nameOfCard;
            Card player1Card;
            Card player2Card;
            
            Console.WriteLine("1. player choose a card you want to play by typing in its name!");
            nameOfCard = Console.ReadLine();
            player1Card = deck.GetCardByName(player1.hand, nameOfCard);
            Console.WriteLine("2. player choose a card you want to play by typing in its name!");
            nameOfCard = Console.ReadLine();
            player2Card=deck.GetCardByName(player2.hand, nameOfCard);
            Table round = new Table(player1Card, player2Card);
            round.GetWinner();
        }
        public void RunProgramWith1v1()
        {
            int lastTimeWon = 1;
            Player player1 = new Player()


        }
    }
}
