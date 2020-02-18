using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{

    abstract class Card
    {
        public string name;
        public int armorpen;
        public Card(string name,int armorpen)
        {
            this.name = name;
            this.armorpen = armorpen;
        }
    }
}
