using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class Table
    {
        Card Player1Card { get; set; }
        Card Player2Card { get; set; }
        public Table(Card player1card , Card player2card)
        {
            Player1Card = player1card;
            Player2Card = player2card;
        }
        public Card CompareCard(Card card1, Card card2)
        {
            return null;
        }
        public  Player GetWinner()
        {
            return null;
        }

        public Card ChooseCard(Player player)
        {
            return null;
        }
    }
}
