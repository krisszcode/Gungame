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
        /// <summary>
        /// Compares two cards for their attributes and returns the winning card.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="wonBefore"></param>
        /// <returns></returns>
        public Card CompareCard(string attribute,string wonBefore)
        {
            //If the two cardtypes don't match, the player who started the round wins, their card gets returned here
            if(Player1Card is KnifeCard && Player2Card is WeaponCard || Player1Card is WeaponCard && Player2Card is KnifeCard)
            {
                if (wonBefore.Equals("player1"))
                {
                    return Player1Card;
                }
                else
                {
                    return Player2Card;
                }
            }
            //If both cards are knives, and the chosen attribute is sharpness, checks which card's attribute is higher
            else if(Player1Card is KnifeCard && Player2Card is KnifeCard && attribute.ToLower() == "sharpness")
            {
                if ((Player1Card as KnifeCard).sharpness > (Player2Card as KnifeCard).sharpness)
                {
                    return Player1Card;
                }
                else return Player2Card;
                
            }
            //If both cards are weapons, and the chosen attribute is firerate, checks which card's attribute is higher
            else if (Player1Card is WeaponCard && Player2Card is WeaponCard && attribute.ToLower() == "firerate")
            {
                if ((Player1Card as WeaponCard).fireRate > (Player2Card as WeaponCard).fireRate)
                {
                    return Player1Card;
                }
                else return Player2Card;
            }
            //If the chosen attribute is armorpen , returns which card's attribute is higher. Both knives and weapons have this attribute.
            else if (attribute.ToLower() == "armorpen")
            {
                if (Player1Card.armorpen > Player2Card.armorpen)
                {
                    return Player1Card;
                }
                else return Player2Card;
            }
            throw new Exception("Szar az egész");
        }
        /// <summary>
        /// Returns the winner, after checking who had the winning card in hand.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public  Player GetRoundWinner(Player player1 , Player player2, string attribute)
        {
            string wonBefore = getWonBeforePlayer(player1);
            Card wonCard = CompareCard(attribute,wonBefore);

            if (wonCard.Equals(Player1Card))
            {
                return player1;
            }
            else if (wonCard.Equals(Player2Card))
            {
                return player2;
            }
            else throw new Exception("full szar");
        }
        /// <summary>
        /// Returns the player who won the last round
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public string getWonBeforePlayer(Player player1)
        {
            if(player1.wonBefore == true)
            {
                return "player1";
            }
            else
            {
                return "player2";
            }
        }
    }
}
