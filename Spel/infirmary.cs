using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Infirmary
    {
        public static void InfirmaryDefault(Gladiator player)
        {
            var MissingHealth = player.health - player.currentHealth;
            TextHandler.PrintHeaderText("John the Saints Infirmary");
            TextHandler.PrintCenteredText($"1. Full Heal. Heal to full for {MissingHealth + 20}", 4);
            TextHandler.PrintCenteredText($"2. Lesser Heal. Heal {player.gold - 20} for {player.gold}");
            TextHandler.PrintCenteredText("3. Back to town");
            TextHandler.CenteredCursorPosition();
        }

        public static void Heal(Gladiator player)
        {
            player.gold -= player.health - player.currentHealth + 20;
            player.currentHealth = player.health;
        }
        public static void LesserHeal(Gladiator player)
        {
            player.currentHealth += player.gold - 20;
            player.gold = 0;
        }
    }
}
