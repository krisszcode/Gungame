using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class WeaponCard : Card
    {
        public int fireRate;
        public WeaponCard(string name , int armorpen, int fireRate) : base(name ,armorpen)
        {
            this.fireRate = fireRate;
        }
    }
}
