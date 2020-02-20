using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
namespace Gungame.GungameData
{
    class CardHandler
    {
        public List<Card> deck = new List<Card>();
        /// <summary>
        /// Generates a random number between 0 and the current deck size.
        /// </summary>
        /// <returns></returns>
        protected int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, deck.Count);          
        }
        /// <summary>
        /// Deals out 4 cards to the players from the deck and removes them from the deck.
        /// </summary>
        /// <returns></returns>
        public List<Card> FirstHandDealer()
        {
            List<Card> playerHand = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                Card card = deck[GenerateRandomNumber()];
                playerHand.Add(card);
                deck.Remove(card);
            }
            return playerHand;  
        }
        /// <summary>
        /// Adds one card to a player's hand and removes the given card from the deck.
        /// </summary>
        /// <param name="player"></param>
        public void DealACardToHand(Player player)
        {
            if (deck.Count > 0)
            {
                Card card = deck[GenerateRandomNumber()];
                player.hand.Add(card);
                deck.Remove(card);
            }
        }
        /// <summary>
        /// This gets called after every round.
        /// Removes the card that has been played from the player's hand and replaces it with another card from the deck.
        /// </summary>
        /// <param name="playedCard"></param>
        /// <param name="player"></param>
        public void RoundEndDeal(Card playedCard,Player player)
        {
            player.RemoveACardFromHand(playedCard);
            DealACardToHand(player);
        }
        /// <summary>
        /// From a given card's name returns the card that matches the name.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Card GetCardByName(List<Card> hand,string name)
        {
            foreach(Card card in hand)
            {
                if (card.name.ToLower().Equals(name.ToLower()))
                {
                    return card;
                }
            }
            throw new Exception();
        }      
    }
}
