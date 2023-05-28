using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleTurnBasedRpg
{
    internal class Monster
    {
        int health;
        public int max_health;
        int attackPower;
        int magicPower;
        public string name;

        public Monster(int _health, int _attackPower, int _magicPower, string _name)
        {
            this.health = _health;
            this.max_health = _health;
            this.attackPower = _attackPower;
            this.magicPower = _magicPower;
            this.name = _name;
        }
        public void ModifyHealth(int modifier)
        {
            this.health += modifier;
        }

        public int Action(float modifier)
        {
            Random random = new();
            int action = random.Next(0, 2);
            if(action == 1)
            {
                int dmg = Attack(modifier);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(this.name + " attacks and deals " + dmg + " damage!");
                Console.ResetColor();
                return dmg;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(this.name + " heals " + Heal(modifier) + " HP!");
                Console.ResetColor();
                return 0;
            }
        }

        private int Attack(float modifier)
        {
            return (int)Math.Ceiling(this.attackPower * modifier);
        }

        private int Heal(float modifier)
        {
            int heal = (int)Math.Ceiling(this.magicPower * modifier);
            ModifyHealth(heal);
            return heal;
        }

        public int GetHealth()
        {
            float percentage = (float)this.health / (float)this.max_health * 100;
            return (int)Math.Floor(percentage);
        }
    }
}
