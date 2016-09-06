using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.Lego_Blocks
{
    public class LegoBlock
    {
        public static void Main()
        {
            Dictionary<int, List<string>> legoBlocks = new Dictionary<int, List<string>>();

            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n * 2; i++)
            {
                legoBlocks.Add(i, new List<string>(Console.ReadLine()
                    .Trim()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()));
            }

            int lengthRows = legoBlocks[0].Count + legoBlocks[0 + n].Count;

            int count = 1;
            while (count < n && (legoBlocks[count].Count + legoBlocks[count + n].Count) == lengthRows)
            {
                count++;
            }

            if (count == n)
            {
                PrintLegoBlock(legoBlocks, n);
            }
            else
            {
                var cellsCount = legoBlocks.Values.Sum(v => v.Count);
                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
        }

        private static void PrintLegoBlock(Dictionary<int, List<string>> legoBlocks, int n)
        {
            for (int i = 0; i < n; i++)
            {
                legoBlocks[i + n].Reverse();
                Console.WriteLine("[" + string.Join(", ", legoBlocks[i]) + ", " +
                    string.Join(", ", legoBlocks[i + n]) + "]");
            }
        }
    }
}
