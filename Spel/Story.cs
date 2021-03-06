﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Story
    {

        public List<Gladiator> gladiators = new List<Gladiator>();
        public List<Weapon> weapons = new List<Weapon>();
        public List<Armor> armors = new List<Armor>();
        public List<Enchantments> enchantments = new List<Enchantments>();

        public String Location = "town";

        public Story()
        {
            gladiators.Add(new Gladiator("Russel", 5, 0, 50, 1, 1, 0, 10));
            gladiators.Add(new Gladiator("Father O’Farter", 3, 0, 50, 3, 2, 50));
            gladiators.Add(new Gladiator("Garbage Beast", 5, 2, 110, 4, 5, 110));
            gladiators.Add(new Gladiator("Xavier the Reclusive", 7 , 4, 150, 7, 7, 170));
            gladiators.Add(new Gladiator("Krull", 12, 6, 210, 10, 10, 230));
            gladiators.Add(new Gladiator("Gorion o'Loughlin", 17, 8, 290, 13, 14, 290));
            gladiators.Add(new Gladiator("Thor, son of Krull", 20, 10, 370, 16, 16, 350));
            gladiators.Add(new Gladiator("Phranc", 25, 12, 530, 21, 22, 410));
            gladiators.Add(new Gladiator("Atlas the lost", 32, 14, 610, 26, 27, 470));
            gladiators.Add(new Gladiator("Yorick", 42, 16, 690, 32, 32, 530));
            gladiators.Add(new Gladiator("The Missing Rasta", 55, 18, 770, 37, 38, 590));
            gladiators.Add(new Gladiator("Zeus 'God of Thunder, God King of Olympus, Slayer of man", 100, 20, 2000, 44, 55, 9999));

            weapons.Add(new Weapon("A Fish", 4, 20));
            weapons.Add(new Weapon("Wooden Sword", 7, 45));
            weapons.Add(new Weapon("Gladius", 11, 85));
            weapons.Add(new Weapon("Spear", 16, 150));
            weapons.Add(new Weapon("Minotaur Axe", 23, 250));
            weapons.Add(new Weapon("Huge Boulder", 32, 380));
            weapons.Add(new Weapon("The Executioner", 44, 550));
            weapons.Add(new Weapon("Longsword of Xavius the third", 57, 780));
            weapons.Add(new Weapon("Big Hammer", 73, 1000));
            weapons.Add(new Weapon("Prometheus' Blade 'Flame of the Gods'", 100, 1380));

            armors.Add(new Armor("Quilted Armor", 10, 18));
            armors.Add(new Armor("Boiled Elk Vest", 20, 50));
            armors.Add(new Armor("Bronzed Battleplate", 30, 80));
            armors.Add(new Armor("Ring Mail", 50, 175));
            armors.Add(new Armor("Light Plate", 70, 280));
            armors.Add(new Armor("Iron Hauberk", 90, 420));
            armors.Add(new Armor("Ancient Armor", 120, 600));
            armors.Add(new Armor("Fierce Bone Vest", 150, 800));
            armors.Add(new Armor("The Fortress 'Pride of Troy'", 190, 1025));
            armors.Add(new Armor("Skin of Achilles", 250, 1500));

            enchantments.Add(new Enchantments("Lifesteal", "lifesteal", 1, 500));
            enchantments.Add(new Enchantments("Lifesteal", "lifesteal", 2, 1250));
            enchantments.Add(new Enchantments("Lifesteal", "lifesteal", 3, 2000));


            this.GameScreen();
            this.Introduction();
            this.ChapterOne();
            this.TownArrival();
            Game();
        }

        public void Game()
        {
            while (true)
            {
                switch (this.Location)
                {
                    case "town":
                        Console.Clear();
                        this.Location = Town.TownDefaultText(this.gladiators[0]);
                        break;
                    case "arena":
                        var running = true;
                        bool playerTurn = false;
                        bool isHeavyAttack = false;
                        bool enemyTurn = false;
                        var displayDamage = "";

                        while (running)
                        {

                            Console.Clear();

                            if (this.gladiators[1].currentHealth <= 0)
                            {
                                if (this.gladiators[1].name.Contains("Zeus"))
                                {
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You have defeated all the gladiators", 20);
                                    TextHandler.PrintCenteredText("You have earned the blessing of the gods");
                                    TextHandler.PrintCenteredText("You shall have your freedom");
                                    TextHandler.PrintCenteredText("You may return to england...for now.");
                                    Console.ReadLine();
                                    System.Environment.Exit(1);


                                }
                                this.gladiators[0].enemiesDefeated += 1;
                                Console.ResetColor();
                                TextHandler.PrintCenteredText($"You chopped off {this.gladiators[1].name}'s head", 20);
                                TextHandler.PrintCenteredText("The crowd roars!");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                TextHandler.PrintCenteredText($"Winnings: {this.gladiators[1].gold} Gold", 1);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                TextHandler.PrintCenteredText("== Level Up! ==", 1);
                                Console.ResetColor();
                                TextHandler.PrintCenteredText("You gained:", 1);
                                Console.ForegroundColor = ConsoleColor.Green;
                                TextHandler.PrintCenteredText($"strength + {this.gladiators[0].enemiesDefeated / 2}", 1);
                                TextHandler.PrintCenteredText($"agility + {this.gladiators[0].enemiesDefeated / 2}");
                                TextHandler.PrintCenteredText($"attack + 2");
                                TextHandler.PrintCenteredText($"health + 10");
                                Console.ResetColor();

                                Console.ResetColor();
                                this.gladiators[0].strength += (this.gladiators[0].enemiesDefeated / 2);
                                this.gladiators[0].agility += (this.gladiators[0].enemiesDefeated / 2);
                                this.gladiators[0].attack += 2;
                                this.gladiators[0].health += 15;
                                this.gladiators[0].currentHealth += 10;

                                this.gladiators[0].skillPoints += 5;
                                this.gladiators[0].gold += this.gladiators[1].gold;
                                var earnedGold = this.gladiators[0].gold = (this.gladiators[0].gold * 3) / 2;
                                Console.ReadLine();
                                this.gladiators.Remove(this.gladiators[1]);
                                this.Location = "town";
                                running = false;
                                break;
                            }

                            Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);

                            Arena.ChooseAction(this.gladiators[0],this.gladiators[1]);

                            var input = Console.ReadLine();

                            switch (input)
                            {
                                case "1":
                                    playerTurn = true;
                                    isHeavyAttack = false;
                                    break;
                                case "2":
                                    playerTurn = true;
                                    isHeavyAttack = true;
                                    break;
                                case "3":
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You scatter gold all around you whilst fleeing for the arena", 24);
                                    TextHandler.PrintCenteredText($"You have lost {this.gladiators[0].gold / 2} gold");
                                    Console.ResetColor();
                                    this.gladiators[0].gold = this.gladiators[0].gold / 2;
                                    Console.ReadKey();
                                    playerTurn = false;
                                    enemyTurn = false;
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }

                            if (playerTurn)
                            {
                                string damageDealt = "";
                                if (!isHeavyAttack)
                                {
                                    damageDealt = this.gladiators[0].AttackMove(this.gladiators[1]);
                                }
                                if (isHeavyAttack)
                                {
                                    damageDealt = this.gladiators[0].HeavyAttack(this.gladiators[1]);
                                }
                                Console.Clear();
                                displayDamage = $"{this.gladiators[0].name}{damageDealt}";
                                Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);
                                if (displayDamage.Contains("critically") == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                }
                                if (displayDamage.Contains("dodged") == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                TextHandler.PrintCenteredText(displayDamage);
                                Console.ReadLine();

                                if(gladiators[1].currentHealth > 0)
                                {

                                    enemyTurn = true;
                                    
                                }

                                playerTurn = false;

                            }

                            if (enemyTurn)
                            {
                                Console.Clear();
                                string damageDealt = this.gladiators[1].AttackMove(this.gladiators[0]);
                                displayDamage = $"{this.gladiators[1].name}{damageDealt}";
                                Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);
                                if (displayDamage.Contains("critically") == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                if (displayDamage.Contains("dodged") == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                                TextHandler.PrintCenteredText(displayDamage);
                                Console.ReadLine();
                                enemyTurn = false;
                                playerTurn = true;
                                if (gladiators[0].currentHealth <= 0)
                                {
                                    Console.Clear();
                                    this.GameOver();
                                }
                            }
                            
                        }
                        break;

                    case "armory":
                        running = true;
                        while (running)
                        {
                            int i = 0;
                            Console.Clear();
                            Armory.ArmoryDefault();
                            TextHandler.PrintGladiatorStats(gladiators[0], false);
                            TextHandler.CenteredCursorPosition();
                            var input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.Clear();
                                    TextHandler.PrintGladiatorStats(gladiators[0], false);
                                    TextHandler.PrintCenteredText("", -18);
                                    foreach (var weapon in this.weapons)
                                    {
                                        i++;
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        TextHandler.PrintCenteredText(i.ToString());
                     
                                        Console.ResetColor();
                                        TextHandler.PrintWeaponInfo(weapon);
                                    }
                                    TextHandler.PrintCenteredText("11. Go back", 2);
                                    TextHandler.CenteredCursorPosition();
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            Armory.BuyWeapon(gladiators[0], weapons[0]);
                                            break;
                                        case "2":
                                            Armory.BuyWeapon(gladiators[0], weapons[1]);
                                            break;
                                        case "3":
                                            Armory.BuyWeapon(gladiators[0], weapons[2]);
                                            break;
                                        case "4":
                                            Armory.BuyWeapon(gladiators[0], weapons[3]);
                                            break;
                                        case "5":
                                            Armory.BuyWeapon(gladiators[0], weapons[4]);
                                            break;
                                        case "6":
                                            Armory.BuyWeapon(gladiators[0], weapons[5]);
                                            break;
                                        case "7":
                                            Armory.BuyWeapon(gladiators[0], weapons[6]);
                                            break;
                                        case "8":
                                            Armory.BuyWeapon(gladiators[0], weapons[7]);
                                            break;
                                        case "9":
                                            Armory.BuyWeapon(gladiators[0], weapons[8]);
                                            break;
                                        case "10":
                                            Armory.BuyWeapon(gladiators[0], weapons[9]);
                                            break;
                                        case "11":
                                            running = false;
                                            break;
                                        default:
                                            break;
                                    }

                                    break;

                                case "2":
                                    Console.Clear();
                                    TextHandler.PrintGladiatorStats(gladiators[0], false);
                                    TextHandler.PrintCenteredText("", -18);
                                    int j = 0;
                                    foreach (var armor in this.armors)
                                    {
                                        j++;
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        TextHandler.PrintCenteredText(j.ToString());
                                        Console.ResetColor();
                                        TextHandler.PrintArmorInfo(armor);
                                    }

                                    TextHandler.PrintCenteredText("11. Go back", 2);
                                    TextHandler.CenteredCursorPosition();
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            Armory.BuyArmor(gladiators[0], armors[0]);
                                            break;
                                        case "2":
                                            Armory.BuyArmor(gladiators[0], armors[1]);
                                            break;
                                        case "3":
                                            Armory.BuyArmor(gladiators[0], armors[2]);
                                            break;
                                        case "4":
                                            Armory.BuyArmor(gladiators[0], armors[3]);
                                            break;
                                        case "5":
                                            Armory.BuyArmor(gladiators[0], armors[4]);
                                            break;
                                        case "6":
                                            Armory.BuyArmor(gladiators[0], armors[5]);
                                            break;
                                        case "7":
                                            Armory.BuyArmor(gladiators[0], armors[6]);
                                            break;
                                        case "8":
                                            Armory.BuyArmor(gladiators[0], armors[7]);
                                            break;
                                        case "9":
                                            Armory.BuyArmor(gladiators[0], armors[8]);
                                            break;
                                        case "10":
                                            Armory.BuyArmor(gladiators[0], armors[9]);
                                            break;
                                        case "11":
                                            running = false;
                                            break;
                                        default:
                                            break;
                                    }
                                    break;

                                default:
                                    break;
                                case "3":
                                    running = false;
                                    this.Location = "town";
                                    break;
                            }
                        }
                            break;

                        case "infirmary":
                        running = true;
                        while (running)
                        {

                            Console.Clear();
                            if (Infirmary.AlreadyFullHealth(gladiators[0]))
                            {
                                running = false;
                                this.Location = "town";
                                break;
                            }
                            Infirmary.InfirmaryDefault(this.gladiators[0]);
                            var input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    if (Infirmary.AlreadyFullHealth(gladiators[0]))
                                    {
                                        running = false;
                                        this.Location = "town";
                                        break;
                                    }
                                    if (gladiators[0].gold < gladiators[0].health - gladiators[0].currentHealth +20)
                                    {
                                        Console.Clear();
                                        TextHandler.PrintCenteredText("You cannot afford this right now", 24);
                                        Console.ReadKey();
                                        running = false;
                                        break;
                                    }
                                    Infirmary.Heal(this.gladiators[0]);
                                    this.Location = "town";
                                    running = false;
                                    break;  
                                case "2":
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }

                        }
                             break;
                    case "training":
                        running = true;
                        while (running)
                        {
                            Console.Clear();
                            Training.TrainingDefault();
                            TextHandler.PrintGladiatorStats(gladiators[0], false);
                            TextHandler.CenteredCursorPosition();
                            var input = Console.ReadLine();
                             if (gladiators[0].skillPoints <= 0 && input != "4")
                             {
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You dont have any skillpoints", 24);
                                    Console.ReadLine();
                                    this.Location = "town";
                                    running = false;
                                    break;

                             }
                            switch (input)
                            {
                                case "1":
                                    Skillpoints.AddStrength(this.gladiators[0]);
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You feel stronger", 24);
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Skillpoints.AddAgility(this.gladiators[0]);
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You feel faster", 24);
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Skillpoints.AddStamina(this.gladiators[0]);
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("You feel larger", 24);
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }
                            break;
                        }
                        break;
                    case "magic shop":
                        int l = 0;
                        running = true;
                        while (running)
                        {
                            Console.Clear();
                            MagicShop.MagicShopDefault();
                            TextHandler.PrintGladiatorStats(gladiators[0], false);
                            TextHandler.CenteredCursorPosition();
                            var input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.Clear();
                                    TextHandler.PrintGladiatorStats(gladiators[0], false);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    TextHandler.PrintCenteredText("1", -20);
                                    Console.ResetColor();
                                    TextHandler.PrintEnchantment(enchantments[0]);
                                    TextHandler.PrintCenteredText("2. Go back", 2);
                                    TextHandler.CenteredCursorPosition();
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            Console.Clear();
                                            TextHandler.PrintGladiatorStats(gladiators[0], false);
                                            TextHandler.PrintCenteredText("", -20);
                                            foreach (var enchantment in this.enchantments)
                                            {
                                                l++;
                                                TextHandler.PrintCenteredText("", 1);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                TextHandler.PrintCenteredText(l.ToString());
                                                Console.ResetColor();
                                                TextHandler.PrintEnchantmentInfo(enchantment);
                                            }
                                            TextHandler.PrintCenteredText("4. Go to town", 1);
                                            TextHandler.CenteredCursorPosition();
                                            input = Console.ReadLine();
                                            switch (input)
                                            {
                                                case "1":
                                                    MagicShop.BuyEnchantment(gladiators[0],enchantments[0]);
                                                    break;
                                                case "2":
                                                    MagicShop.BuyEnchantment(gladiators[0], enchantments[1]);
                                                    break;
                                                case "3":
                                                    MagicShop.BuyEnchantment(gladiators[0], enchantments[2]);
                                                    break;
                                                case "4":
                                                    this.Location = "town";
                                                    running = false;
                                                    break;

                                                default:
                                                    break;
                                            }


                                            break;

                                        case "2":
                                            this.Location = "town";
                                            running = false;
                                            break;
                                        default:
                                            break;
                                    }
                               break;

                               case "2":
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }
                            break;
 
                            }
                        break;
                        }
                
            }
        }

        private void BuyWeapon(Gladiator gladiator, Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TextHandler.PrintCenteredText("  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ", 24);
            TextHandler.PrintCenteredText(" ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒");
            TextHandler.PrintCenteredText("▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒");
            TextHandler.PrintCenteredText("░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ");
            TextHandler.PrintCenteredText("░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒");
            TextHandler.PrintCenteredText(" ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░");
            TextHandler.PrintCenteredText("  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░");
            TextHandler.PrintCenteredText("░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ");
            TextHandler.PrintCenteredText("      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ");
            TextHandler.PrintCenteredText("                                                     ░                   ");
            System.Environment.Exit(1);
        }

        public void kleggorys()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            TextHandler.PrintCenteredText("                                     ██ ▄█▀ ██▓    ▓█████   ▄████   ▄████  ▒█████   ██▀███ ▓██   ██▓  ██  ██████                                             ", 20);
            TextHandler.PrintCenteredText("                                     ██▄█▒ ▓██▒    ▓█   ▀  ██▒ ▀█▒ ██▒ ▀█▒▒██▒  ██▒▓██ ▒ ██▒▒██  ██▒▒    ██    ▒                                             ");
            TextHandler.PrintCenteredText("                                    ▓███▄░ ▒██░    ▒███   ▒██░▄▄▄░▒██░▄▄▄░▒██░  ██▒▓██ ░▄█ ▒ ▒██ ██░░     ▓██▄                                               ");
            TextHandler.PrintCenteredText("                                    ▓██ █▄ ▒██░    ▒▓█  ▄ ░▓█  ██▓░▓█  ██▓▒██   ██░▒██▀▀█▄   ░ ▐██▓░      ▒   ██▒                                            ");
            TextHandler.PrintCenteredText("                                    ▒██▒ █▄░██████▒░▒████▒░▒▓███▀▒░▒▓███▀▒░ ████▓▒░░██▓ ▒██▒ ░ ██▒▓░▒    ██████▒▒                                            ");
            TextHandler.PrintCenteredText("                                    ▒ ▒▒ ▓▒░ ▒░▓  ░░░ ▒░ ░ ░▒   ▒  ░▒   ▒ ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░  ██▒▒▒ ▒     ▒▓▒ ▒ ░                                            ");
            TextHandler.PrintCenteredText("                                    ░ ░▒ ▒░░ ░ ▒  ░ ░ ░  ░  ░   ░   ░   ░   ░ ▒ ▒░   ░▒ ░ ▒░▓██ ░▒░ ░     ░▒  ░ ░                                            ");
            TextHandler.PrintCenteredText("                                    ░ ░░ ░   ░ ░      ░   ░ ░   ░ ░ ░   ░ ░ ░ ░ ▒    ░░   ░ ▒ ▒ ░░  ░      ░  ░                                              ");
            TextHandler.PrintCenteredText("                                    ░  ░       ░  ░   ░  ░      ░       ░     ░ ░     ░     ░ ░            ░                                              ");
            TextHandler.PrintCenteredText("                                                                                            ░ ░                                                          ");
            TextHandler.PrintCenteredText("  ██████  █     █░ ▒█████   ██▀███  ▓█████▄   ██████     ▄▄▄       ███▄    █ ▓█████▄      ██████  ▄▄▄       ███▄    █ ▓█████▄  ▄▄▄       ██▓      ██████ ");
            TextHandler.PrintCenteredText("▒██    ▒ ▓█░ █ ░█░▒██▒  ██▒▓██ ▒ ██▒▒██▀ ██▌▒██    ▒    ▒████▄     ██ ▀█   █ ▒██▀ ██▌   ▒██    ▒ ▒████▄     ██ ▀█   █ ▒██▀ ██▌▒████▄    ▓██▒    ▒██    ▒ ");
            TextHandler.PrintCenteredText("░ ▓██▄   ▒█░ █ ░█ ▒██░  ██▒▓██ ░▄█ ▒░██   █▌░ ▓██▄      ▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌   ░ ▓██▄   ▒██  ▀█▄  ▓██  ▀█ ██▒░██   █▌▒██  ▀█▄  ▒██░    ░ ▓██▄   ");
            TextHandler.PrintCenteredText("  ▒   ██▒░█░ █ ░█ ▒██   ██░▒██▀▀█▄  ░▓█▄   ▌  ▒   ██▒   ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌     ▒   ██▒░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█▄   ▌░██▄▄▄▄██ ▒██░      ▒   ██▒");
            TextHandler.PrintCenteredText("▒██████▒▒░░██▒██▓ ░ ████▓▒░░██▓ ▒██▒░▒████▓ ▒██████▒▒    ▓█   ▓██▒▒██░   ▓██░░▒████▓    ▒██████▒▒ ▓█   ▓██▒▒██░   ▓██░░▒████▓  ▓█   ▓██▒░██████▒▒██████▒▒");
            TextHandler.PrintCenteredText("▒ ▒▓▒ ▒ ░░ ▓░▒ ▒  ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▒▓  ▒ ▒ ▒▓▒ ▒ ░    ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒    ▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░░ ▒░   ▒ ▒  ▒▒▓  ▒  ▒▒   ▓▒█░░ ▒░▓  ░▒ ▒▓▒ ▒ ░");
            TextHandler.PrintCenteredText("░ ░▒  ░ ░  ▒ ░ ░    ░ ▒ ▒░   ░▒ ░ ▒░ ░ ▒  ▒ ░ ░▒  ░ ░     ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒    ░ ░▒  ░ ░  ▒   ▒▒ ░░ ░░   ░ ▒░ ░ ▒  ▒   ▒   ▒▒ ░░ ░ ▒  ░░ ░▒  ░ ░");
            TextHandler.PrintCenteredText("░  ░  ░    ░   ░  ░ ░ ░ ▒    ░░   ░  ░ ░  ░ ░  ░  ░       ░   ▒      ░   ░ ░  ░ ░  ░    ░  ░  ░    ░   ▒      ░   ░ ░  ░ ░  ░   ░   ▒     ░ ░   ░  ░  ░  ");
            TextHandler.PrintCenteredText("      ░      ░        ░ ░     ░        ░          ░           ░  ░         ░    ░             ░        ░  ░         ░    ░          ░  ░    ░  ░      ░  ");
            TextHandler.PrintCenteredText("                                     ░                                        ░                                        ░                                 ");
            Console.ResetColor();
            Console.ReadLine();
        }   

        public void GameScreen()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.ForegroundColor = ConsoleColor.Red;

            TextHandler.PrintCenteredText(" ▄▄▄▄   ██▓    ▒█████  ▒█████ ▓█████▄   ", 5);
            TextHandler.PrintCenteredText("▓█████▄▓██▒   ▒██▒  ██▒██▒  ██▒██▀ ██▌  ");
            TextHandler.PrintCenteredText("▒██▒ ▄█▒██░   ▒██░  ██▒██░  ██░██   █▌  ");
            TextHandler.PrintCenteredText("▒██░█▀ ▒██░   ▒██   ██▒██   ██░▓█▄   ▌  ");
            TextHandler.PrintCenteredText("░▓█  ▀█░██████░ ████▓▒░ ████▓▒░▒████▓   ");
            TextHandler.PrintCenteredText("░▒▓███▀░ ▒░▓  ░ ▒░▒░▒░░ ▒░▒░▒░ ▒▒▓  ▒   ");
            TextHandler.PrintCenteredText(" ░        ▒█████  ███▄    █ ░    ░      ");
            TextHandler.PrintCenteredText("      ░  ▒██▒  ██▒██ ▀█   █    ░        ");
            TextHandler.PrintCenteredText("         ▒██░  ██▓██  ▀█ ██▒   ░        ");
            TextHandler.PrintCenteredText("         ▒██   ██▓██▒  ▐▌██▒            ");
            TextHandler.PrintCenteredText("         ░ ████▓▒▒██░   ▓██░     ░      ");
            TextHandler.PrintCenteredText("         ░ ▒░░░▒░░ ▒░   ▒ ▒      ░      ");
            TextHandler.PrintCenteredText("         ░ ░ ░ ▒    ░   ░ ░             ");
            TextHandler.PrintCenteredText("         ▄▄▄█████▓██░ ██▓█████   ▒      ");
            TextHandler.PrintCenteredText("         ▓  ██▒ ▓▓██░ ██▓█   ▀   ░      ");
            TextHandler.PrintCenteredText("         ▒ ▓██░ ▒▒██▀▀██▒███            ");
            TextHandler.PrintCenteredText("     ▒   ░ ▓██▓ ░░▓█ ░██▒▓█  ▄    ▒     ");
            TextHandler.PrintCenteredText("           ▒██▒ ░░▓█▒░██░▒████▒   ░  ░  ");
            TextHandler.PrintCenteredText("             ░    ▒ ░▒░ ░░ ░  ░         ");
            TextHandler.PrintCenteredText("           ░      ░  ░░ ░  ░       ░    ");
            TextHandler.PrintCenteredText(" ▄▄▄       ██████ ░██████  ░  ██▓    ██▓");
            TextHandler.PrintCenteredText("▒████▄   ▒██    ▒▒██    ▒    ▓██▒   ▓██▒");
            TextHandler.PrintCenteredText("▒██  ▀█▄ ░ ▓██▄  ░ ▓██▄      ▒██▒   ▒██▒");
            TextHandler.PrintCenteredText("░██▄▄▄▄██  ▒   ██▒ ▒   ██▒   ░██░   ░██░");
            TextHandler.PrintCenteredText(" ▓█   ▓██▒██████▒▒██████▒▒   ░██░   ░██░");
            TextHandler.PrintCenteredText(" ▒▒   ▓▒█▒ ▒▓▒ ▒ ▒ ▒▓▒ ▒ ░   ░▓     ░▓  ");
            TextHandler.PrintCenteredText("  ▒   ▒▒ ░ ░▒  ░ ░ ░▒  ░ ░    ▒ ░    ▒ ░");
            TextHandler.PrintCenteredText("  ░   ▒  ░  ░  ░ ░  ░  ░      ▒ ░    ▒ ░");
            TextHandler.PrintCenteredText("      ░  ░     ░       ░      ░      ░  ");
            TextHandler.CenteredCursorPosition();
            Console.ResetColor();
            TextHandler.PrintCenteredText("Press enter to start Game", 2);
            Console.ReadLine();
            Console.Clear();
        }
        public void Introduction()
        {
            Console.ResetColor();
            TextHandler.PrintCenteredText("You are famous gladiator Russel Crow", 10);
            TextHandler.PrintCenteredText("You must fight in the arena and defeat the champion");
            TextHandler.PrintCenteredText("To earn your freedom");
            TextHandler.PrintCenteredText("And return to england");
            TextHandler.PrintCenteredText("Do you have what it takes?", 1);
            TextHandler.CenteredCursorPosition();
            Console.ReadLine();
            Console.Clear();
        }

        public void ChapterOne()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TextHandler.PrintCenteredText(" ▄████▄   ██░ ██  ▄▄▄       ██▓███  ▄▄▄█████▓▓█████  ██▀███      ██▓                  ", 10);
            TextHandler.PrintCenteredText("▒██▀ ▀█  ▓██░ ██▒▒████▄    ▓██░  ██▒▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒   ▓██▒                  ");
            TextHandler.PrintCenteredText("▒▓█    ▄ ▒██▀▀██░▒██  ▀█▄  ▓██░ ██▓▒▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒   ▒██▒                  ");
            TextHandler.PrintCenteredText("▒▓▓▄ ▄██▒░▓█ ░██ ░██▄▄▄▄██ ▒██▄█▓▒ ▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄     ░██░                  ");
            TextHandler.PrintCenteredText("▒ ▓███▀ ░░▓█▒░██▓ ▓█   ▓██▒▒██▒ ░  ░  ▒██▒ ░ ░▒████▒░██▓ ▒██▒   ░██░                  ");
            TextHandler.PrintCenteredText("░ ░▒ ▒  ░ ▒ ░░▒░▒ ▒▒   ▓▒█░▒▓▒░ ░  ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░   ░▓                    ");
            TextHandler.PrintCenteredText("  ░  ▒    ▒ ░▒░ ░  ▒   ▒▒ ░░▒ ░         ░     ░ ░  ░  ░▒ ░ ▒░    ▒ ░                  ");
            TextHandler.PrintCenteredText("░         ░  ░░ ░  ░   ▒   ░░         ░         ░     ░░   ░     ▒ ░                  ");
            TextHandler.PrintCenteredText("░ ░       ░  ░  ░      ░  ░                     ░  ░   ░         ░                    ");
            TextHandler.PrintCenteredText("░                                                                                     ");
            TextHandler.PrintCenteredText(" ▄▄▄▄    ▄▄▄      ▓█████▄     █     █░▓█████ ▄▄▄     ▄▄▄█████▓ ██░ ██ ▓█████  ██▀███  ");
            TextHandler.PrintCenteredText("▓█████▄ ▒████▄    ▒██▀ ██▌   ▓█░ █ ░█░▓█   ▀▒████▄   ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒");
            TextHandler.PrintCenteredText("▒██▒ ▄██▒██  ▀█▄  ░██   █▌   ▒█░ █ ░█ ▒███  ▒██  ▀█▄ ▒ ▓██░ ▒░▒██▀▀██░▒███   ▓██ ░▄█ ▒");
            TextHandler.PrintCenteredText("▒██░█▀  ░██▄▄▄▄██ ░▓█▄   ▌   ░█░ █ ░█ ▒▓█  ▄░██▄▄▄▄██░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄  ");
            TextHandler.PrintCenteredText("░▓█  ▀█▓ ▓█   ▓██▒░▒████▓    ░░██▒██▓ ░▒████▒▓█   ▓██▒ ▒██▒ ░ ░▓█▒░██▓░▒████▒░██▓ ▒██▒");
            TextHandler.PrintCenteredText("░▒▓███▀▒ ▒▒   ▓▒█░ ▒▒▓  ▒    ░ ▓░▒ ▒  ░░ ▒░ ░▒▒   ▓▒█░ ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░");
            TextHandler.PrintCenteredText("▒░▒   ░   ▒   ▒▒ ░ ░ ▒  ▒      ▒ ░ ░   ░ ░  ░ ▒   ▒▒ ░   ░     ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░");
            TextHandler.PrintCenteredText(" ░    ░   ░   ▒    ░ ░  ░      ░   ░     ░    ░   ▒    ░       ░  ░░ ░   ░     ░░   ░ ");
            TextHandler.PrintCenteredText(" ░            ░  ░   ░           ░       ░  ░     ░  ░         ░  ░  ░   ░  ░   ░     ");
            TextHandler.PrintCenteredText("      ░            ░                                                                  ");
            Console.ResetColor();

            Console.ReadLine();
            Console.Clear();
        }

        public void ArenaHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TextHandler.PrintCenteredText(" ▄████▄   ▒█████   ██▓     ▒█████    ██████   ██████ ▓█████  █    ██  ███▄ ▄███▓", 10);
            TextHandler.PrintCenteredText("▒██▀ ▀█  ▒██▒  ██▒▓██▒    ▒██▒  ██▒▒██    ▒ ▒██    ▒ ▓█   ▀  ██  ▓██▒▓██▒▀█▀ ██▒");
            TextHandler.PrintCenteredText("▒▓█    ▄ ▒██░  ██▒▒██░    ▒██░  ██▒░ ▓██▄   ░ ▓██▄   ▒███   ▓██  ▒██░▓██    ▓██░");
            TextHandler.PrintCenteredText("▒▓▓▄ ▄██▒▒██   ██░▒██░    ▒██   ██░  ▒   ██▒  ▒   ██▒▒▓█  ▄ ▓▓█  ░██░▒██    ▒██ ");
            TextHandler.PrintCenteredText("▒ ▓███▀ ░░ ████▓▒░░██████▒░ ████▓▒░▒██████▒▒▒██████▒▒░▒████▒▒▒█████▓ ▒██▒   ░██▒");
            TextHandler.PrintCenteredText("░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░░ ▒░ ░░▒▓▒ ▒ ▒ ░ ▒░   ░  ░");
            TextHandler.PrintCenteredText("  ░  ▒     ░ ▒ ▒░ ░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░░ ░▒  ░ ░ ░ ░  ░░░▒░ ░ ░ ░  ░      ░");
            TextHandler.PrintCenteredText("░        ░ ░ ░ ▒    ░ ░   ░ ░ ░ ▒  ░  ░  ░  ░  ░  ░     ░    ░░░ ░ ░ ░      ░   ");
            TextHandler.PrintCenteredText("░        ░ ░ ░ ▒    ░ ░   ░ ░ ░ ▒  ░  ░  ░  ░  ░  ░     ░    ░░░ ░ ░ ░      ░   ");
            TextHandler.PrintCenteredText("░ ░          ░ ░      ░  ░    ░ ░        ░        ░     ░  ░   ░            ░   ");
            TextHandler.PrintCenteredText("░                                                                              ");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }

        public void Welcome()
        {
            TextHandler.PrintCenteredText("Startled, you wake up to the sounds of the raging storm outside your hut.", 10);
            TextHandler.PrintCenteredText("Unable to fall back to sleep");
            TextHandler.PrintCenteredText("You decide to:");
            TextHandler.PrintCenteredText("1. Go to town");
            TextHandler.PrintCenteredText("2. Go back to sleep");
            TextHandler.CenteredCursorPosition();
        }

        public void TownArrival()
        {
            Welcome();
            string response = Console.ReadLine();
            bool running = true;
            var really = "";
            while (running)
            {
                switch (response)
                {
                    case "1":
                        Console.Clear();
                        running = false;
                        break;
                    case "2":
                        Console.Clear();
                        Welcome();
                        TextHandler.PrintCenteredText($"you{really} can't sleep");
                        really += " really";
                        TextHandler.CenteredCursorPosition();
                        response = Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Welcome();
                        TextHandler.PrintCenteredText($"{response} is not a valid option");
                        TextHandler.CenteredCursorPosition();
                        response = Console.ReadLine();
                        break;
                }
            }
        }
       
    }
}
