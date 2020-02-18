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
        public Card CompareCard()
        {

            
        }
        public  Player GetWinner(Player player1 , Player player2)
        {
            Card wonCard = CompareCard();
            
            if (wonCard.Equals(Player1Card)) {
                return player1;
                    }
            else if (wonCard.Equals(Player2Card))
            {
                return player2;
            }

        }

        /*public Card ChooseCard(Player player)
        {

        }*/
    }
}
