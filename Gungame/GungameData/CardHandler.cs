using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class CardHandler
    {
        public List<Card> deck = new List<Card>();
        


        protected int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, 33);

        }

        public void Dealer(Player player1, Player player2)
        {

            for (int i = 0; i < 5; i++)
            {
                Card card = deck[GenerateRandomNumber()];
                player1.hand.Add(card);
                deck.Remove(card);
            }

            for (int i = 0; i < 5; i++)
            {
                Card card = deck[GenerateRandomNumber()];
                player2.hand.Add(card);
                deck.Remove(card);
            }
        }
        
       

    }

}
