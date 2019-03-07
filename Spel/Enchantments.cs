using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Enchantments
    {
        public string name { get; set; }
        public string type { get; set; }
        public int level { get; set; }
        public int Cost { get; set; }


        public Enchantments(string name, string type, int level, int Cost)
        {
            this.name = name;
            this.type = type;
            this.level = level;
            this.Cost = Cost;
        }

    }
}
