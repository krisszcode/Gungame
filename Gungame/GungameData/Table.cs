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
        public Card CompareCard(string attribute,string wonBefore)
        {
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
            else if(Player1Card is KnifeCard && Player2Card is KnifeCard && attribute.ToLower() == "sharpness")
            {
                if ((Player1Card as KnifeCard).sharpness > (Player2Card as KnifeCard).sharpness)
                {
                    return Player1Card;
                }
                else return Player2Card;
                
            }
            else if(Player1Card is WeaponCard && Player2Card is WeaponCard && attribute.ToLower() == "firerate")
            {
                if ((Player1Card as WeaponCard).fireRate > (Player2Card as WeaponCard).fireRate)
                {
                    return Player1Card;
                }
                else return Player2Card;
            }
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
        public  Player GetRoundWinner(Player player1 , Player player2, string attribute)
        {
            string wonBefore = getWonBeforePlayer(player1, player2);
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

        public string getWonBeforePlayer(Player player1, Player player2)
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

        /*public Card ChooseCard(Player player)
        {

        }*/

        public List<Card> RemoveUsedCardAfterRound(Player player,Card card1)
        {
            List<Card> temp = new List<Card>();
            foreach (Card card2 in player.hand)
            {
                temp.Add(card2);
                foreach (Card card in temp)
                {
                    if (card.name.Equals(card1.name))
                    {
                        temp.Remove(card);
                    }

                }
                
            }
            return temp;
        }
    }
}
