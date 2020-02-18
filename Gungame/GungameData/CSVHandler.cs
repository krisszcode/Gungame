using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gungame.GungameData
{
    class CSVHandler
    {
        public List<Card> listOfCards = new List<Card>();
        public void CsvHandler(string path)
        {
            var weapons = new List<WeaponCard>();
            var knieves = new List<KnifeCard>();
            
            string name;
            int attribute1;
            int attribute2;
            using (var rd = new StreamReader(path))
            {
                int linecounter = 0;
                while (!rd.EndOfStream)
                {
                    linecounter++;
                    if (linecounter < 17)
                    {
                        var line = rd.ReadLine();
                        var values = line.Split(',');
                        name = values[0];
                        attribute1 = Int32.Parse(values[1]);
                        attribute2 = Int32.Parse(values[2]);
                        var knieve = new KnifeCard(name,attribute1,attribute2);
                        knieves.Add(knieve);
                        listOfCards.Add(knieve);
                    }
                    else
                    {
                        var line = rd.ReadLine();
                        var values = line.Split(',');
                        name = values[0];
                        attribute1 = Int32.Parse(values[1]);
                        attribute2 = Int32.Parse(values[2]);
                        var weapon = new WeaponCard(name, attribute1, attribute2);
                        weapons.Add(weapon);
                        listOfCards.Add(weapon);
                    }
                }
            }
        }
    }
}
