using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Town
    {
        public static string TownDefaultText(Gladiator gladiator)
        {
            TextHandler.PrintHeaderText("Beggar's Hole");
            TextHandler.PrintCenteredText("1. Arena", 4);
            TextHandler.PrintCenteredText("2. Armory");
            TextHandler.PrintCenteredText("3. Infirmary");
            TextHandler.PrintCenteredText("4. Training");
            TextHandler.PrintGladiatorStats(gladiator, false);
            TextHandler.CenteredCursorPosition();
            var result = Console.ReadLine();
            Console.Clear();
            while (true)
            {
                switch (result)
                {
                    case "1":
                        return "arena";
                    case "2":
                        return "armory";
                    case "3":
                        return "infirmary";
                    case "4":
                        return "training";

                    default:
                        return "town";
                        
                }
            }
        }
    }
}
