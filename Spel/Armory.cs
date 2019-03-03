using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Armory
    {
        public static void ArmoryDefault()
        {
            TextHandler.PrintHeaderText("Kleggory's Swords and Sandals");
            TextHandler.PrintCenteredText("1. Weapons", 4);
            TextHandler.PrintCenteredText("2. Armor");
            TextHandler.PrintCenteredText("3. Back to town");
            TextHandler.CenteredCursorPosition();

        }

        public static void BuyWeapon(Gladiator player, Weapon weapon)
        {
            if (player.gold > weapon.Cost)
            {
                player.RemoveGoldForWeapon(weapon);
                player.AddWeaponAttack(weapon);
                player.weapon = weapon.name;
            }
            else
            {
                Console.Clear();
                TextHandler.PrintCenteredText($"You cannot afford {weapon.name}", 24);
                Console.ReadLine();
            }
        }
        public static void BuyArmor(Gladiator player, Armor armor)
        {
            if (player.gold > armor.Cost)
            {
                player.RemoveGoldForArmor(armor);
                player.AddArmor(armor);
                player.armorName = armor.name;
            }
            else
            {
                Console.Clear();
                TextHandler.PrintCenteredText($"You cannot afford {armor.name}", 24);
                Console.ReadLine();
            }
        }
        
    }
}
