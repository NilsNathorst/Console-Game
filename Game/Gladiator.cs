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
        public int currentHealth { get; set; }
        public int gold { get; set; }
        public int skillPoints { get; set; }
        public string weapon { get; set; }
        public string armor { get; set; }




        public Gladiator(string name, int attack, int defence, int health, int gold = 0, int skillPoints = 0, string weapon = "", string armor = "")
        {

            this.name = name;
            this.attack = attack;
            this.defence = defence;
            this.health = health;
            this.currentHealth = health;
            this.gold = gold;
            this.skillPoints = skillPoints;
            this.weapon = weapon;
            this.armor = armor;
        }

        public int AttackMove(Gladiator enemy)
        {
            Random random = new Random();
            int damage = random.Next(this.attack - (this.attack / 2), this.attack + (this.attack / 2));
            damage = damage - (defence / 3);
            enemy.TakeDamage(damage);
            return damage;
        }

        public int AddWeaponAttack(Weapon weapon)
        {
            return this.attack += weapon.damage;
        }

        public int AddArmor(Armor armor)
        {
            return this.defence += armor.defence;
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
