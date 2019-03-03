using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class TextHandler
    {
        public string value { get; set; }
        public int offset { get; set; }

        public static void CenteredCursorPosition(string value = "", int offset = 0)
        {
            Console.SetCursorPosition((Console.WindowWidth - value.Length) / 2, Console.CursorTop + offset);
        }
      
        public static void PrintCenteredText(string value, int offset = 0)
        {
            CenteredCursorPosition(value, offset);
            Console.WriteLine(value);
        }
        public static void RightAlignText(string value, int offset = 0)
        {
            Console.SetCursorPosition((Console.WindowWidth - value.Length) - 10, Console.CursorTop + offset);
            Console.WriteLine(value);
        }

        public static void LeftAlignText(string value, int offset = 0)
        {
            Console.SetCursorPosition(10, Console.CursorTop + offset);
            Console.WriteLine(value);
        }
        
        public static void PrintHeaderText(string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCenteredText(value.ToUpper(), 10);
            Console.ResetColor();
        }
        public static void PrintWeaponInfo(Weapon weapon)
        {;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenteredText($"== {weapon.name} ==");
            Console.ResetColor();
            PrintCenteredText($"Damage: {weapon.damage}");
            PrintCenteredText($"Cost: {weapon.Cost}");
        }
        public static void PrintArmorInfo(Armor armor)
        {
            ;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenteredText($"== {armor.name} ==");
            Console.ResetColor();
            PrintCenteredText($"Armor: {armor.armor}");
            PrintCenteredText($"Cost: {armor.Cost}");
        }
        public static void PrintGladiatorStats(Gladiator gladiator, bool npc, string location = "")
        {
            if (npc)
            {
                Console.SetCursorPosition(0, 24);
                Console.ForegroundColor = ConsoleColor.Red;
                RightAlignText($"== {gladiator.name} ==");
                RightAlignText($"Attack: {gladiator.attack}");
                RightAlignText($"Defence: {gladiator.defence}");
                RightAlignText($"Health: {gladiator.currentHealth}/{gladiator.health}");
                Console.ResetColor();
                
                    
            }
            else if (!npc)
            {
            Console.SetCursorPosition(0, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            LeftAlignText($"== {gladiator.name} ==",4);
            LeftAlignText($"Attack: {gladiator.attack}");
            LeftAlignText($"Defence: {gladiator.defence}");
            LeftAlignText($"Health: {gladiator.currentHealth}/{gladiator.health}");
                
                if (gladiator.armorName != "" || gladiator.weapon != "")
                {
                    LeftAlignText($"Items: {gladiator.armorName}, {gladiator.weapon}");
                    LeftAlignText($"Armor: {gladiator.armorRating}");
                }
                if (location != "arena")
                {
                    LeftAlignText($"Gold: {gladiator.gold}");
                    LeftAlignText($"SkillPoints: {gladiator.skillPoints}");
                    LeftAlignText($"Strength: {gladiator.strength}");
                    LeftAlignText($"Agility: {gladiator.agility}");
                }
            Console.ResetColor();
            }
        }
    }
}
