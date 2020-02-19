using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class AI : Player
    {
        public AI( List<Card> hand, string name = "ai", int wonHands = 0, bool wonBefore = false) : base(name, hand, wonHands, wonBefore)
        {
        }

        public string KnifeOrWep(Card enemyPlayed)
        {
            if (enemyPlayed is KnifeCard)
            {
                return "knife";
            }
            else return "weapon";
        }
        public List<Card> GetKnifeFromHand()
        {
            List<Card> temp = new List<Card>();
            foreach(Card aiCard in hand)
            {
                if(aiCard is KnifeCard)
                {
                    temp.Add(aiCard);
                }
            }
            return temp;
        }
        public List<Card> GetWepFromHand()
        {
            List<Card> temp = new List<Card>();
            foreach (Card aiCard in hand)
            {
                if (aiCard is WeaponCard)
                {
                    temp.Add(aiCard);
                }
            }
            return temp;
        }
        public bool AttributeCheck(Card aiCard,Card enemyCard, string attribute)
        {
            if (KnifeOrWep(enemyCard).Equals("weapon"))
            {
                if (aiCard is WeaponCard)
                {
                    if (attribute.Equals("armorpen"))
                    {
                        if (aiCard.armorpen > enemyCard.armorpen)
                        {
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        if ((aiCard as WeaponCard).fireRate > (enemyCard as WeaponCard).fireRate)
                        {
                            return true;
                        }
                        return false;

                    }
                }
                else return false;
            }
            else 
            {
                
                if (aiCard is KnifeCard)
                {  
                    if (attribute.Equals("armorpen"))
                    {
                        if (aiCard.armorpen > enemyCard.armorpen)
                        {
                            return true;
                        }
                        return false;

                    }
                    else
                    {
                        if ((aiCard as KnifeCard).sharpness > (enemyCard as KnifeCard).sharpness)
                        {
                            return true;
                        }
                        return false;

                    }
                }
                else return false;
            }
        }
        public Card FalseBranch()
        {
            List<Card> weaponCards = GetWepFromHand();
            List<Card> knifeCards = GetKnifeFromHand();
            if (weaponCards.Count > knifeCards.Count)
            {
                return weaponCards[0];
            }
            else if (weaponCards.Count < knifeCards.Count)
            {
                return knifeCards[0];
            }
            else return hand[0];
        }


        public Card ChooseTheRightCardForAI(Card enemycard,string attribute)
        {
            for (int  i = 0;  i < hand.Count;  i++)
            {
                if (AttributeCheck(enemycard, hand[i], attribute) == true)
                {
                    return hand[i];
                }
                
            }
            return FalseBranch();
        }

    }
}
