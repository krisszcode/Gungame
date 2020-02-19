using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class KnifeCard : Card
    {
        public int sharpness;
        public KnifeCard(string name, int armorpen, int sharpness) : base(name,armorpen)
        {
           this.sharpness = sharpness;
        }

        public override string ToString()
        {
            return base.ToString() + $"Sharpness: {this.sharpness}";
        }
    }
}
