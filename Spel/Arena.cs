using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Arena
    {
        public static void DisplayStats(Gladiator player, Gladiator enemy)
        { 
            TextHandler.PrintGladiatorStats(player, false, "arena");
            TextHandler.PrintGladiatorStats(enemy, true, "arena");
        }

        public static void ChooseAction(Gladiator player, Gladiator enemy)
        {
            var DodgeChance = (enemy.agility % 5);

            TextHandler.PrintCenteredText($"1. Attack {90 - DodgeChance}  %");
            var toHit = (33) + player.strength;
            if (toHit > 100)
            {
                toHit = 100;
            }
            TextHandler.PrintCenteredText($"2. Heavy Attack {toHit} %");
            TextHandler.PrintCenteredText("3. Run");
            TextHandler.CenteredCursorPosition();
        }
    }
    
}
