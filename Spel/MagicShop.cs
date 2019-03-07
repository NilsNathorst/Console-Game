using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class MagicShop
    {
        public static void MagicShopDefault()
        {
            TextHandler.PrintHeaderText("Merlin the wise's Spells and Enchantments");
            TextHandler.PrintCenteredText("1. Enchantments", 4);
            TextHandler.PrintCenteredText("2. Back to town");
            TextHandler.CenteredCursorPosition();

        }

        public static void BuyEnchantment(Gladiator player, Enchantments enchantment)
        {
            if (player.gold > enchantment.Cost)
            {
                player.enchantmentName = "";
                player.enchantmentLevel = 0;
                player.RemoveGoldForEnchantment(enchantment);
                player.enchantmentName = enchantment.name;
                player.enchantmentLevel = enchantment.level;
            }
            else
            {
                Console.Clear();
                TextHandler.PrintCenteredText($"You cannot afford {enchantment.name}", 24);
                Console.ReadLine();
            }
        }
       
    }
}

