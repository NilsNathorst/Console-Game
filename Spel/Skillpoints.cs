using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Skillpoints
    {

        public static void AddStrength(Gladiator player)
        {
            player.skillPoints -= 1;
            player.strength += 1;
        }
        public static void AddAgility(Gladiator player)
        {
            player.skillPoints -= 1;
            player.agility+= 1;
        }
        public static void AddStamina(Gladiator player)
        {
            player.skillPoints -= 1;
            player.health += 5;
        }
    }
}
