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
        public int enemiesDefeated { get; set; }

        public Gladiator(string name, int attack, int armorRating, int health, int strength = 1, int agility = 1, int gold = 0, int skillPoints = 0, string weapon = "Wooden Club", int weaponDamage = 0, string armorName = "Ragged Clothes", int enemiesDefeated = 0)
        {
            this.name = name;
            this.attack = attack;
            this.strength = strength;
            this.agility = agility;
            this.health = health;
            this.currentHealth = health;
            this.gold = gold;
            this.skillPoints = skillPoints;
            this.weapon = weapon;
            this.weaponDamage = weaponDamage;
            this.armorName = armorName;
            this.armorRating = armorRating;
            this.enemiesDefeated = enemiesDefeated;
        }

        public string AttackMove(Gladiator enemy)
        {

            //var IsCriticalHit = CritMod(this.agility);
            //var IsDodge = DodgeMod(enemy.agility);
            //var defenceMod = this.agility + this.defence;
            //var attackMod = this.strength + this.attack;
            //Random random = new Random();
            //int damage = random.Next(attackMod - (attackMod / 2), attackMod + (attackMod / 2));
            //damage = damage * IsCriticalHit;
            //damage = damage - (defenceMod / 2);
            //damage = damage * IsDodge;
            //enemy.TakeDamage(damage);

            var IsCriticalHit = CritMod(this.agility);
            var IsDodge = DodgeMod(10);
            int DamageReduction = this.agility + this.armorRating;
            int DefenceMod = DamageReduction / 4;
            int StrengthOfAttack = (this.strength * 2) + (this.attack);
            int PartialSum = StrengthOfAttack / 5;
            int MinimumDamage = PartialSum * 3;
            int MaximumDamage = PartialSum * 4;
            Random random = new Random();
            int MinOrMax = random.Next(MinimumDamage, MaximumDamage);
            int damage = MinOrMax * IsCriticalHit;
            damage -= DefenceMod;
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
            //var IsCriticalHit = CritMod(this.agility);
            //var IsDodge = DodgeMod(enemy.agility + 40 - this.strength);
            //var defenceMod = this.defence * this.armorRating;
            //var attackMod = (this.strength * 3 / 2) + this.attack;
            //Random random = new Random();
            //int damage = random.Next(attackMod - (attackMod / 2), attackMod + (attackMod / 2));
            //damage = (damage * IsCriticalHit) + (this.strength * 3 / 2);
            //damage = damage * IsDodge;
            //enemy.TakeDamage(damage);

            var IsCriticalHit = CritMod(this.agility);
            var IsDodge = DodgeMod(66 - this.strength);
            int DamageReduction = this.agility + this.armorRating;
            int DefenceMod = DamageReduction / 8;
            int StrengthOfAttack = (this.strength * 4) + (this.attack);
            int PartialSum = StrengthOfAttack / 5;
            int MinimumDamage = PartialSum * 3;
            int MaximumDamage = PartialSum * 4;
            Random random = new Random();
            int MinOrMax = random.Next(MinimumDamage, MaximumDamage);
            int damage = MinOrMax * IsCriticalHit;
            damage -= DefenceMod;
            damage = damage * IsDodge;
            if (damage <= 0)
            {
                damage = 1;
            }
            enemy.TakeDamage(damage);

            var output = $"'s Heavy attack hit {enemy.name} for {damage} damage";
            if (IsCriticalHit == 2)
            {
                output = $"'s Heavy attack critically hit {enemy.name} for {damage} damage";
            }
            if (IsDodge == 0)
            {
                output = $"'s Heavy attack was dodged by {enemy.name}";
            }
            return output;
        }

        public static int CritMod(int agility)
        {
            var modifier = 1;
            Random random = new Random();
            int critChance = random.Next(1, 100);
            if (critChance < agility + 15)
            {
                modifier = 2;
            }
            return modifier;
        }

        public static int DodgeMod(int number)
        {
            var modifier = 1;
            Random random = new Random();
            int critChance = random.Next(1, 100);
            if (critChance < number)
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
