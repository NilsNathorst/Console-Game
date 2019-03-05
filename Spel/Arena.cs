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
            var toHit = 100 - enemy.agility - 10;
            TextHandler.PrintCenteredText($"1. Attack {toHit} %");
            toHit = (50 - enemy.agility - 10) + player.strength;
            TextHandler.PrintCenteredText($"2. Heavy Attack {toHit} %");
            TextHandler.PrintCenteredText("3. Run");
            TextHandler.CenteredCursorPosition();
        }
    }
    
}
