using System;
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

        public String Location = "town";

        public Story()
        {
            gladiators.Add(new Gladiator("Russel", 5, 0, 50, 0));
            gladiators.Add(new Gladiator("Vincenzo Salvatore", 5, 0, 40));
            gladiators.Add(new Gladiator("Garbage Beast", 5, 2, 45));
            gladiators.Add(new Gladiator("Xavier the Reclusive", 10, 4, 72));
            gladiators.Add(new Gladiator("Krull", 7, 6, 100));
            gladiators.Add(new Gladiator("Gorion o'Loughlin", 20, 8, 120));
            gladiators.Add(new Gladiator("Thor, son of Krull", 25, 10, 100));
            gladiators.Add(new Gladiator("Phranc", 30, 12, 150));
            gladiators.Add(new Gladiator("Atlas the lost", 40, 14, 50));
            gladiators.Add(new Gladiator("Kay Kay", 50, 16, 100));
            gladiators.Add(new Gladiator("The Missing Rasta", 55, 18, 100));
            gladiators.Add(new Gladiator("Nage of Shackleford", 60, 20, 300));

            weapons.Add(new Weapon("A Fish", 1, 10));
            weapons.Add(new Weapon("The Executioner", 50, 300));
            weapons.Add(new Weapon("Longsword of Xavius the third", 70, 500));
            weapons.Add(new Weapon("Infinity Edge", 100, 1000));

            armors.Add(new Armor("Leather Shield", 5, 10));
            armors.Add(new Armor("Basic Armor", 10, 15));
            armors.Add(new Armor("The Fortress", 15, 20));

            
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
                        bool enemyTurn = false;
                        var displayDamage = "";
                        while (running)
                        {

                            Console.Clear();

                            if (this.gladiators[1].currentHealth <= 0)
                            {
                                TextHandler.PrintCenteredText($"You chopped off {this.gladiators[1].name}'s head", 30);
                                TextHandler.PrintCenteredText("You have gained gold and experience");
                                this.gladiators[0].skillPoints += 5;
                                this.gladiators[0].gold += 100;
                                Console.ReadLine();
                                this.gladiators.Remove(this.gladiators[1]);
                                this.Location = "town";
                                running = false;
                                break;
                            }

                            Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);

                            Arena.ChooseAction();

                            var input = Console.ReadLine();

                            switch (input)
                            {
                                case "1":
                                    playerTurn = true;
                                    break;
                                case "2":
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }

                            if (playerTurn)
                            {
                                Console.Clear();
                                int damageDealt = this.gladiators[0].AttackMove(this.gladiators[1]);
                                displayDamage = $"{this.gladiators[0].name} hits {this.gladiators[1].name} for {damageDealt} damage";
                                Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);
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
                                int damageDealt = this.gladiators[1].AttackMove(this.gladiators[0]);
                                displayDamage = $"{this.gladiators[1].name} hits {this.gladiators[0].name} {damageDealt} damage";
                                Arena.DisplayStats(this.gladiators[0], this.gladiators[1]);
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
                            var input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("", 8);
                                    foreach (var weapon in this.weapons)
                                    {
                                        i++;
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        TextHandler.PrintCenteredText(i.ToString());
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ResetColor();
                                        TextHandler.PrintWeaponInfo(weapon);
                                    }

                                    Console.SetCursorPosition(76, 43);
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
                                            Armory.BuyWeapon(gladiators[0], weapons[1]);
                                            break;
                                        case "4":
                                            Armory.BuyWeapon(gladiators[0], weapons[1]);
                                            break;
                                        case "5":
                                            break;
                                        default:
                                            break;
                                    }

                                    break;

                                case "2":
                                    Console.Clear();
                                    TextHandler.PrintCenteredText("", 8);
                                    int j = 0;
                                    foreach (var armor in this.armors)
                                    {
                                        j++;
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        TextHandler.PrintCenteredText(j.ToString());
                                        TextHandler.PrintCenteredText("", 1);
                                        Console.ResetColor();
                                        TextHandler.PrintArmorInfo(armor);
                                    }

                                    Console.SetCursorPosition(76, 43);
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            Armory.BuyArmor(gladiators[0], armors[0]);
                                            break;
                                        case "2":
                                            Armory.BuyArmor(gladiators[0], armors[1]);
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
                            Infirmary.InfirmaryDefault(this.gladiators[0]);
                            var input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Infirmary.Heal(this.gladiators[0]);
                                    running = false;
                                    break;
                                case "3":
                                    this.Location = "town";
                                    running = false;
                                    break;
                            }

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
