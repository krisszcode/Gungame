﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gungame.GungameData
{
    class Card
    {
        public string name;
        public int armorpen;

        public Card(string name,int armorpen)
        {
            this.name = name;
            this.armorpen = armorpen;
        }

        public override string ToString()
        {
            return $"Name: {this.name}{Environment.NewLine}Armorpen: {this.armorpen}{Environment.NewLine}";
        }
    }
}
