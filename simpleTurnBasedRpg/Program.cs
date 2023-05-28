using simpleTurnBasedRpg;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

internal class Program
{
    static float RandFloat()
    {
        Random random = new();

        double fail = 0.5;
        float success = 2;

        int roll = random.Next(1,21);
        if (roll == 1) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Critical failure!");
            Console.ResetColor();
            return (float)fail;
        }
        else if(roll == 20)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Critical success!");
            Console.ResetColor();
            return (float)success;
        }
        double val = (random.NextDouble() * (1.1 + 0.9) * 1);
        return (float)val;
    }

    private static void Main(string[] args)
    {
        Player player = new(40,10,5,"Player");
        List<Monster> monsters = new()
        {
            new(10, 3, 2, "Dragon Cultist"),
            new(20, 6, 4, "Dragon Wyrmling"),
            new(30, 10, 6, "Adolecent Dragon"),
            new(50, 15, 10, "Anchinet Dragon"),
            new(120, 30, 20, "Demorrah, the Dragon Godess")
        };

        string devider = "";
        for (int i = 0; i < Console.BufferWidth; i++)
        devider += "=";
        int timer = 300;
        string decorator = "|////////////////|";

        Console.WriteLine("What is your name?");
        var name = Console.ReadLine();
        if(name != null)
        {
            player.name = name;
        }
        Console.WriteLine("Why hello " + player.name + "!");
        Console.WriteLine("Pepare for carnage : )");
        Thread.Sleep(timer*3);
        Console.Clear();
        while (monsters.Count > 0 && player.health > 0) {
            Monster monster = monsters.First();
            Console.WriteLine(monster.name + " stands before you!");
            Console.WriteLine(devider);
            Thread.Sleep(timer);
            while (player.health > 0 && monster.GetHealth() > 0)
            {
                Console.WriteLine(decorator + " " + player.name + "'s turn " + decorator);
                Console.WriteLine("Attack 'a' or heal 'h'");
                var input = Console.ReadLine();
                if (input != null && input == "a")
                {
                    int attack = player.Attack(RandFloat());
                    monster.ModifyHealth(-attack);
                }
                else
                {
                    player.Heal(RandFloat());
                }
         
                Console.WriteLine(devider);

                Thread.Sleep(timer);
                if (monster.GetHealth() > 0) { 

                    Console.WriteLine(decorator + " " + monster.name + "'s turn " + decorator);
                    int dmg = monster.Action(RandFloat());
                    player.ModifyHealth(-dmg);

                    Console.WriteLine(devider);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(player.name + " has " + player.health + "HP!");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(monster.name + " has " + monster.GetHealth() + "% HP left!");
                    Console.ResetColor();

                    Console.WriteLine(devider);
                }
            }
            Console.Clear();
            Console.WriteLine(monster.name + " defeated! You have leveled up, so all your stats have increased!");
            player.LevelUp();
            Thread.Sleep(timer);
            Console.WriteLine("You move further into the dungeon...");
            Thread.Sleep(timer*4);
            Console.Clear();
            monsters.Remove(monster);
        }
        if(player.health > 0)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Congratz! You defeated all the monsters in the dungeon!");
        }
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aweh... Better luck next time :("); 
        }


    }
}