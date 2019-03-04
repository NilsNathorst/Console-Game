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

        public static void ChooseAction()
        {
                TextHandler.PrintCenteredText("1. Attack");
                TextHandler.PrintCenteredText("2. Heavy Attack");
                TextHandler.PrintCenteredText("3. Run");
                TextHandler.CenteredCursorPosition();
        }
    }
    
}
