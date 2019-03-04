using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Gladiator
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int defence { get; set; }
        public int health { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        public int currentHealth { get; set; }
        public int gold { get; set; }
        public int skillPoints { get; set; }
        public string weapon { get; set; }
        public int weaponDamage { get; set; } 
        public int armorRating { get; set; } 
        public string armorName { get; set; } 

        public Gladiator(string name, int attack, int defence, int health, int strength = 1, int agility = 1, int gold = 0, int skillPoints = 0, string weapon = "Wooden Club", int weaponDamage = 0, string armorName = "Ragged Clothes", int armorRating = 0)
        {
            this.name = name;
            this.attack = attack;
            this.strength = strength;
            this.agility = agility;
            this.defence = defence;
            this.health = health;
            this.currentHealth = health;
            this.gold = gold;
            this.skillPoints = skillPoints;
            this.weapon = weapon;
            this.weaponDamage = weaponDamage;
            this.armorName = armorName;
            this.armorRating = armorRating;
        }

        public string AttackMove(Gladiator enemy)
        {
            var IsCriticalHit = CritMod(this.strength);
            var IsDodge = DodgeMod(enemy.agility);
            var defenceMod = this.agility + this.defence;
            var attackMod = this.strength + this.attack;
            Random random = new Random();
            int damage = random.Next(attackMod - (attackMod / 2), attackMod + (attackMod / 2));
            damage = damage * IsCriticalHit;
            damage = damage - (defenceMod / 3);
            damage = damage * IsDodge;
            enemy.TakeDamage(damage);
            var output = $" hit {enemy.name} for {damage} damage";
            if (IsCriticalHit == 2)
            {
                output = $" critically hit {enemy.name} for {damage} damage";
               
            }
            if (IsDodge == 0)
            {
                output = $"'s attack was dodged by {enemy.name}";
                
            }
            return output;
        }
        public string HeavyAttack(Gladiator enemy)
        {
            var IsCriticalHit = CritMod(this.strength);
            var IsDodge = DodgeMod(enemy.agility + 30);
            var defenceMod = this.defence * this.armorRating;
            var attackMod = (this.strength / 2 + 1) * this.attack;
            Random random = new Random();
            int damage = random.Next(attackMod - (attackMod / 2), attackMod + (attackMod / 2));
            damage = damage * IsCriticalHit + this.strength * 3;
            damage = damage * IsDodge;
            enemy.TakeDamage(damage);
            var output = $"'s Heavy Attack hit {enemy.name} for {damage} damage";
            if (IsCriticalHit == 2)
            {
                output = $"'s Heavy Attack critically hit {enemy.name} for {damage} damage";

            }
            if (IsDodge == 0)
            {
                output = $"'s Heavy Attack was dodged by {enemy.name}";

            }
            return output;
        }
        public static int CritMod(int strength)
        {
            var modifier = 1;
            Random random = new Random();
            int critChance = random.Next(1, 100);
            if (critChance < strength)
            {
                modifier = 2;
            }
            return modifier;
        }
        public static int DodgeMod(int agility)
        {
            var modifier = 1;
            Random random = new Random();
            int critChance = random.Next(1, 100);
            if (critChance < agility)
            {
                modifier = 0;
            }
            return modifier;
        }

        public int AddWeaponAttack(Weapon weapon)
        {
            this.attack -= this.weaponDamage;
            return this.attack += weapon.damage;
        }

        public int AddArmor(Armor armor)
        {
            this.armorRating = 0;
            return this.armorRating += armor.armor;
        }

        public int RemoveGoldForWeapon(Weapon weapon)
        {
            return this.gold -= weapon.Cost;
        }

        public int RemoveGoldForArmor(Armor armor)
        {
            return this.gold -= armor.Cost;
        }
        
        public void TakeDamage(int damage)
        {
            this.currentHealth -= damage;
        }
    }


}
