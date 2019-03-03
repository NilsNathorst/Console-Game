﻿using System;
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
            TextHandler.PrintCenteredText($"1. Full Heal:{MissingHealth}", 4);
            TextHandler.PrintCenteredText("2. Rest");
            TextHandler.PrintCenteredText("3. Back to town");
            TextHandler.CenteredCursorPosition();
        }

        public static void Heal(Gladiator player)
        {
            player.gold -= player.health - player.currentHealth;
            player.currentHealth = player.health;
        }
    }
}