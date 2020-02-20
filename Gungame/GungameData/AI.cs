using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gungame.GungameData
{
    class AI : Player
    {
        public AI(List<Card> hand, string name = "ai", int wonHands = 0, bool wonBefore = false) : base(name, hand, wonHands, wonBefore)
        {
        }

        // methods for the AI if the player starts the round 
        /// <summary>
        /// Returns if a given card played by the 1. player is a weapon or a knife.
        /// </summary>
        /// <param name="enemyPlayed"></param>
        /// <returns></returns>
        public string KnifeOrWep(Card enemyPlayed)
        {
            if (enemyPlayed is KnifeCard)
            {
                return "knife";
            }
            else return "weapon";
        }
        /// <summary>
        /// Returns a list of cards which contains the knives that the ai has in its hand.
        /// </summary>
        /// <returns></returns>
        public List<Card> GetKnifeFromHand()
        {
            List<Card> temp = new List<Card>();
            foreach (Card aiCard in hand)
            {
                if (aiCard is KnifeCard)
                {
                    temp.Add(aiCard);
                }
            }
            return temp;
        }
        /// <summary>
        /// Returns a list of cards which contains the weapons that the ai has in its hand.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This method checks if there is a card that the ai could win the round with.
        /// Returns true or false.
        /// </summary>
        /// <param name="aiCard"></param>
        /// <param name="enemyCard"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public bool AttributeCheck(Card aiCard, Card enemyCard, string attribute)
        {
            //Checks if the enemy's card is a weapon or a knife.
            if (KnifeOrWep(enemyCard).Equals("weapon"))
            {
                //Checks if the current ai's card and the enemy's card is the same type
                if (aiCard is WeaponCard)
                {
                    //Checks the attribute given by the player
                    if (attribute.Equals("armorpen"))
                    {
                        //Checks if the ai's card's given attribute is better than the enemy's card attribute.
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
        /// <summary>
        /// This executes if the ai doesn't have a card that could win the round.
        /// </summary>
        /// <returns></returns>
        public Card FalseBranch()
        {
            List<Card> weaponCards = GetWepFromHand();
            List<Card> knifeCards = GetKnifeFromHand();
            //Returns a card with a type ,that the ai has more than 2 of.
            if (weaponCards.Count > knifeCards.Count)
            {
                return weaponCards[0];
            }
            else if (weaponCards.Count < knifeCards.Count)
            {
                return knifeCards[0];
            }
            //If the ai has 2 of both types of cards returns the first card in its hand . 
            else return hand[0];
        }
        /// <summary>
        /// This method separates the 2 branches :
        /// -if the ai has a better card than what was played, so it can win
        /// -if the ai can't win 
        /// </summary>
        /// <param name="enemycard"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public Card ChooseTheRightCardForAI(Card enemycard, string attribute)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                if (AttributeCheck(hand[i],enemycard, attribute) == true)
                {
                    //ai wins
                    return hand[i];
                }

            }
            //ai can't win
            return FalseBranch();
        }


        //methods for the AI if the Ai starts the round



        /// <summary>
        ///  Megnézi, hogy melyik típusú lapból van neki több, majd abból választ,
        ///  amiből több van, azért, hogy ha a player rak olyat, amiből kevés van neki, akkor tudjon mit rakni rá, és ne bukja el.
        ///  
        /// Amelyik tipusú kártyából több van, azokat a típusú kártyákat belerakom egy listába, és használom a következő képpen:
        ///  
        /// Megnézi minden egyes kártyánál, hogy melyik statja jobb, és azt választja ki,
        /// ezt úgy kapjuk meg, hogy beadom a két értéket egy listába, és veszem a max értékét a listának.
        /// 
        /// Az aktuális kártya nevét, és max/jobb értékét(a két stat közül választva) elmentem egy dictionarybe key(név)/Value(max érték).
        /// 
        /// Majd megkeresem a dictionary valuek közül a legnagyobbat, és annak a nevét használva megkeresem a kezébe azt a kártyát,
        /// aminek a neve hasonló, és visszaadom
        /// </summary>
        /// <returns>Card to play in the round</returns>
        public Card ChooseCardToPlay()
        {
            // inner method to get the max num from a list
            int Max(List<int> list)
            {
                int max = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > max)
                    {
                        max = list[i];
                    }
                }
                return max;
            }
            // ends here.


            List<Card> weapons = new List<Card>();
            List<Card> knives = new List<Card>();

            foreach (Card card in hand)
            {
                if (card is WeaponCard)
                {
                    weapons.Add(card);
                }
                else
                {
                    knives.Add(card);
                }
            }

            if (weapons.Count > knives.Count)
            {
                Dictionary<string, int> CardAndMaximumValue = new Dictionary<string, int>();

                foreach (WeaponCard card in weapons)
                {
                    CardAndMaximumValue.Add(card.name, Max(GetWeaponCardAttributes(card)));
                }
                int MaxNumFromDic = CardAndMaximumValue.Values.Max();
                string BestCard = CardAndMaximumValue.FirstOrDefault(x => x.Value == MaxNumFromDic).Key;

                return GetBestChoice(BestCard);
            }
            else if (weapons.Count < knives.Count)
            {
                Dictionary<string, int> CardAndMaximumValue = new Dictionary<string, int>();

                foreach (KnifeCard card in knives)
                {
                    CardAndMaximumValue.Add(card.name, Max(GetKnifeCardAttributes(card)));
                }

                int MaxNumFromDic = CardAndMaximumValue.Values.Max();
                string BestCard = CardAndMaximumValue.FirstOrDefault(x => x.Value == MaxNumFromDic).Key;

                return GetBestChoice(BestCard);
            }
            else
            {
                Dictionary<string, int> CardAndMaximumValue = new Dictionary<string, int>();

                foreach (KnifeCard card in knives)
                {
                    CardAndMaximumValue.Add(card.name, Max(GetKnifeCardAttributes(card)));
                }
                foreach (WeaponCard card in weapons)
                {
                    CardAndMaximumValue.Add(card.name, Max(GetWeaponCardAttributes(card)));
                }


                int MaxNumFromDic = CardAndMaximumValue.Values.Max();
                string BestCard = CardAndMaximumValue.FirstOrDefault(x => x.Value == MaxNumFromDic).Key;

                return GetBestChoice(BestCard);

            }
        }
        /// <summary>
        /// Returns the best knife card that the ai could play .
        /// </summary>
        /// <param name="BestCard"></param>
        /// <returns></returns>
        public Card GetBestChoice(string BestCard)
        {
            foreach (Card card in hand)
            {
                if (card.name.Equals(BestCard))
                {
                    return card; 
                }
            }
            throw new Exception("Random exception");
        }
        /// <summary>
        /// Gives back a list with the weapon cards attributes in the ai's hand.
        /// </summary>
        /// <param name="weaponCard"></param>
        /// <returns></returns>
        public List<int> GetWeaponCardAttributes(WeaponCard weaponCard)
        {
            List<int> DecideMaxWep = new List<int>();
            DecideMaxWep.Add(weaponCard.armorpen);
            DecideMaxWep.Add(weaponCard.fireRate);
            return DecideMaxWep;
        }
        /// <summary>
        /// Gives back a list with the knife cards attributes in the ai's hand.
        /// </summary>
        /// <param name="knifeCard"></param>
        /// <returns></returns>
        public List<int> GetKnifeCardAttributes(KnifeCard knifeCard)
        {
            List<int> DecideMaxKnife = new List<int>();
            DecideMaxKnife.Add(knifeCard.armorpen);
            DecideMaxKnife.Add(knifeCard.sharpness);
            return DecideMaxKnife;
        }
        /// <summary>
        /// Returns the card's attribute in string form, that the ai should choose.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public string ReturnBestAttribute(Card card)
        {
            // In case of a knifecard, chooses armorpen or sharpness, depending on which is a higher number.
            string ChooseAttributeForKnife(KnifeCard card)
            {
                int CardArmorPen = ChooseCardToPlay().armorpen;

                KnifeCard knife = (KnifeCard)ChooseCardToPlay();
                int CardSharpness = knife.sharpness;

                if (CardArmorPen > CardSharpness)
                {
                    return "armorpen";
                }
                else if (CardArmorPen < CardSharpness)
                {
                    return "sharpness";
                }
                throw new Exception();
            }
            // In case of a weaponcard, chooses armorpen or firerate, depending on which is a higher number.
            string ChooseAttributeForWeapon(WeaponCard card)
            {
                int CardArmorPen = ChooseCardToPlay().armorpen;

                WeaponCard weapon = (WeaponCard)ChooseCardToPlay();
                int CardFireRate = weapon.fireRate;

                if (CardArmorPen > CardFireRate)
                {
                    return "armorpen";
                }
                else if (CardArmorPen < CardFireRate)
                {
                    return "firerate";
                }
                throw new Exception();
            }

            if (card is WeaponCard)
            {
                return ChooseAttributeForWeapon((WeaponCard)card);
            }
            else if (card is KnifeCard)
            {
               return ChooseAttributeForKnife((KnifeCard)card);
            }
            throw new Exception();
        }
    }
}
