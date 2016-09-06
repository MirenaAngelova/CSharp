using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Dragon_Army
{
    public class DragonArmy
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, Stats>> dragonArmy = 
                new Dictionary<string, Dictionary<string, Stats>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                int num;
                int damage = int.TryParse(input[2], out num) ? int.Parse(input[2]) : 45;
                int health = int.TryParse(input[3], out num)? int.Parse(input[3]) : 250;
                int armor =  int.TryParse(input[4], out num)? int.Parse(input[4]) : 10;

                if (!dragonArmy.ContainsKey(type))
                {
                    dragonArmy.Add(type, new Dictionary<string, Stats>());
                }

                if (!dragonArmy[type].ContainsKey(name))
                {
                    dragonArmy[type].Add(name, new Stats(0, 0, 0));
                }

                dragonArmy[type][name] = new Stats(damage, health, armor);
            }

            foreach (var type in dragonArmy)
            {
                double averageDamage = (double)type.Value.Values.Average(d => d.Damage);
                double averageHealth = (double)type.Value.Values.Average(h => h.Health);
                double averageArmor = (double) type.Value.Values.Average(a => a.Armor);

                Console.WriteLine($"{type.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in dragonArmy[type.Key].OrderBy(t => t.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}," +
                                      $" health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }

    public class Stats
    {

        public Stats(int damage, int health, int armor)
        {
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public int Armor { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }
    }
}
