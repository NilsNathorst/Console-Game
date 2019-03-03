using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Armor
    {
        public string name { get; set; }
        public int defence { get; set; }
        public int Cost { get; set; }


        public Armor(string name, int defence, int Cost)
        {
            this.name = name;
            this.defence = defence;
            this.Cost = Cost;
        }

    }
}
