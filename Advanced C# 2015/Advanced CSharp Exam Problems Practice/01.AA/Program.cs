using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.AA
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> resources = new List<string>();
            List<int> quantities = new List<int>();
            //stone_5 gold_2 wood_7 metal_17
            for (int i = 0; i < input.Length; i++)
            {
                string resource = Regex.Replace(input[i], "_\\d+", String.Empty);
                resources.Add(resource);
                int quantity = int.Parse(Regex.Replace(input[i], "\\D+", string.Empty));
                quantities.Add(quantity);
            }
            int n = int.Parse(Console.ReadLine());
            BigInteger maxValue = 0;
            //stone, gold, wood and food
            string[] validResource = new[] { "stone", "gold", "wood", "food" };
            for (int i = 0; i < n; i++)
            {
                int[] startStep = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int startIndex = startStep[0]%input.Length;
               
                int step = startStep[1];
               
                BigInteger sumQantities = 0;

                if (validResource.Contains(resources[startIndex]))
                {
                    sumQantities += quantities[startIndex];
                }

                int currentIndex = (startIndex + step) % input.Length;
                while (currentIndex != startIndex)
                {
                    if (validResource.Contains(resources[currentIndex]))
                    {
                        sumQantities += quantities[currentIndex];
                    }
                    currentIndex = (currentIndex + step)%input.Length;
                }

                if (sumQantities > maxValue)
                {
                    maxValue = sumQantities;
                }

            }
            Console.WriteLine(maxValue);
        }
    }
}
