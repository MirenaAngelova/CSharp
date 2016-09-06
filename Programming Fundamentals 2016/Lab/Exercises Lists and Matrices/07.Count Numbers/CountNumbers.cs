using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Count_Numbers
{
    public class CountNumbers
    {
        public static void Main(string[] args)
        {
            //List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            //int max = list.Max();
            //int[] counts = new int[max + 1];

            //foreach (var num in list)
            //{
            //    counts[num]++;
            //}

            //for (int i = 0; i < counts.Length; i++)
            //{
            //    if (counts[i] != 0)
            //    {
            //        Console.WriteLine($"{i} -> {counts[i]}");
            //    }
            //}

            //int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //Array.Sort(array);

            //for (int i = 0; i < array.Length; i++)
            //{

            //    int count = 1;
            //    while (i + count < array.Length && array[i] == array[i + count])
            //    {
            //        count++;
            //    }

            //    Console.WriteLine($"{array[i]} -> {count}");
            //    i += count - 1;
            //}

            List<string> list = Console.ReadLine().Split().ToList();

            Dictionary<string, int> equalNumbers = new Dictionary<string, int>();

            foreach (var num in list)
            {
                if (!equalNumbers.ContainsKey(num))
                {
                    equalNumbers.Add(num, 0);
                }

                equalNumbers[num]++;
            }

            foreach (var num in equalNumbers.OrderByDescending(n => n.Key))
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
