using System;
using System.Collections.Generic;
using System.Linq;
class LegoBlocks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<List<int>> legoBlock = new List<List<int>>();

        for (int i = 0; i < 2 * n; i++)
        {
            List<int> arrays = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (i >= n)
            {
                arrays.Reverse();
            }

            legoBlock.Add(arrays);
        }

        int firstLength = legoBlock[0].Count + legoBlock[n].Count;

        for (int i = 1; i < n; i++)
        {
            if (firstLength != (legoBlock[i].Count + legoBlock[i + n].Count))
            {
                int counter = 0;

                foreach (var lego in legoBlock)
                {
                    counter += lego.Count;
                }

                Console.WriteLine("The total number of cells is: {0}", counter);

                return;
            }
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("[" + string.Join(", ", legoBlock[i]) + ", " + 
                string.Join(", ", legoBlock[i + n]) + "]");
        }
    }
}