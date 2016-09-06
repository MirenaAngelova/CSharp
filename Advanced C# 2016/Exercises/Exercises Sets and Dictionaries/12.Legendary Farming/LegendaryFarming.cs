using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Legendary_Farming
{
    public class LegendaryFarming
    {
        public static void Main()
        {
            Dictionary<string, int> keys = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments", 0 },
                {  "motes", 0 }
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                string[] inputToArray = input.Split();
                for (int i = 0; i < inputToArray.Length - 1; i += 2)
                {
                    int quantity = int.Parse(inputToArray[i]);
                    string material = inputToArray[i + 1].ToLower();
                    if (keys.ContainsKey(material))
                    {
                        keys[material] += quantity;

                        if (keys[material] >= 250)
                        {
                            keys[material] -= 250;
                            PrintResult(keys, junk, material);
                            return;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }

                        junk[material] += quantity;
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintResult(
            Dictionary<string, int> keys, 
            Dictionary<string, int> junk, 
            string material)
        {
            string key = GetKey(material);

            Console.WriteLine($"{key} obtained!");
            var orderedKeys = keys.OrderByDescending(k => k.Value).ThenBy(k => k.Key);
            foreach (var k in orderedKeys)
            {
                Console.WriteLine($"{k.Key}: {k.Value}");
            }

            foreach (var j in junk.OrderBy(j => j.Key))
            {
                Console.WriteLine($"{j.Key}: {j.Value}");
            }
        }

        private static string GetKey(string material)
        {
            switch (material)
            {
                case "shards":
                    return Keys.Shadowmourne.ToString();
                    break;
                case "fragments":
                    return Keys.Valanyr.ToString();
                    break;
                default:
                    return Keys.Dragonwrath.ToString();
            }
        }
    }

    public enum Keys
    {
        Shadowmourne,
        Valanyr,
        Dragonwrath
    }
} 
