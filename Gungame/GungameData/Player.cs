using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class Player
    {
        public string name;
        public int wonHands;
        public List<Card> hand;
        public bool wonBefore;

        public Player(string name , List<Card> hand, int wonHands = 0, bool wonBefore = false)
        {
            this.name = name; 
            this.hand = hand;
            this.wonHands = wonHands;
            this.wonBefore = wonBefore;
        }

        public void RemoveACardFromHand(Card card)
        {
            foreach(Card handCard in hand)
            {
                if (card.name.Equals(handCard.name))
                {
                    hand.Remove(handCard);
                    break;
                }
            }
        }
    }
}
