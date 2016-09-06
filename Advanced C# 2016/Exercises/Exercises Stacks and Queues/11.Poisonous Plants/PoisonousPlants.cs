using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Poisonous_Plants
{
    public class PoisonousPlants
    {
        public static void Main()
        {
            Console.ReadLine();
            int[] poisonousPlants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<Plant> plants = new Stack<Plant>();
            //11
            //6 5 8 4 7 10 9 12 13 8 7
            int maxDaysAlive = 0;
            foreach (var poisonousPlant in poisonousPlants)
            {
                int daysAlive = 0;
                while (plants.Count > 0 && poisonousPlant <= plants.Peek().AmountOfPesticide)
                {
                    daysAlive = Math.Max(daysAlive, plants.Pop().DaysAlive);
                }

                daysAlive = plants.Count == 0 ? 0 : daysAlive + 1;
                maxDaysAlive = Math.Max(maxDaysAlive, daysAlive);

                Plant plant = new Plant(poisonousPlant, daysAlive);
                plants.Push(plant);
            }

            Console.WriteLine(maxDaysAlive);
        }
    }
}
