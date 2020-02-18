using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
namespace Gungame.GungameData
{
    class CardHandler
    {
        public List<Card> deck = new List<Card>();
        


        protected int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, 33);
            //Out of range exception itt !!
        }

        public List<Card> Dealer()
        {
            List<Card> playerHand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                Card card = deck[GenerateRandomNumber()];
                playerHand.Add(card);
                deck.Remove(card);
            }
            return playerHand;

            
        }
        public Card GetCardByName(List<Card> hand,string name)
        {
            foreach(Card card in hand)
            {
                if (card.name.ToLower().Equals(name.ToLower()))
                {
                    return card;
                }
            }
            throw new Exception("Nemjó");
        }
       

    }

}
