using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Weapon
    {
        public string name { get; set; }
        public int damage { get; set; }
        public int Cost { get; set; }


        public Weapon(string name, int damage, int Cost)
        {
            this.name = name;
            this.damage = damage;
            this.Cost = Cost;
        }

    }
}
