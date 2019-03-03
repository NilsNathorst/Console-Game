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

        public Gladiator(string name, int attack, int defence, int health, int gold = 0, int skillPoints = 0, string weapon = "", int weaponDamage = 0, string armorName = "", int armorRating = 0, int strength = 1, int agility = 1)
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

        public int AttackMove(Gladiator enemy)
        {
            var defenceMod = this.defence * this.armorRating;
            var attackMod = this.strength * this.attack;
            Random random = new Random();
            int damage = random.Next(attackMod - (attackMod / 2), attackMod + (attackMod / 2));
            damage = damage - (defenceMod / 3);
            enemy.TakeDamage(damage);
            return damage;
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
