

using System.Numerics;

namespace simpleTurnBasedRpg
{
    internal class Player
    {
        public int health;
        int max_health;
        int attackPower;
        int magicPower;
        public string name;

        public Player(int _health, int _atkP, int _magP, string _name) {
            this.health = _health;
            this.max_health = _health;
            this.attackPower = _atkP;
            this.magicPower = _magP;

            this.name = _name;

        }

        public void ModifyHealth(int modifier)
        {
            this.health += modifier;
        }

        public int Attack(float modifier)
        {
            int attack = (int)Math.Ceiling(this.attackPower * modifier);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(this.name + " attacks monster and deals " + attack + " damage!");
            Console.ResetColor();
            return attack;
        }

        public int Heal(float modifier)
        {
            int heal = (int)Math.Ceiling(this.magicPower * modifier);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(this.name + " heals " + heal + " HP!");
            Console.ResetColor();
            ModifyHealth(heal);
            return heal;
        }

        public void LevelUp()
        {
            int difference = this.max_health - this.health;
            this.health = this.max_health + 5 - difference;
            this.attackPower += 2;
            this.magicPower += 2;
        }
    }
}
