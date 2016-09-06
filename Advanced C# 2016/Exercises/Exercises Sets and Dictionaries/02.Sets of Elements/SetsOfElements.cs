using System;
using System.Collections.Generic;

namespace _02.Sets_of_Elements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            HashSet<string> nSet = new HashSet<string>();
            HashSet<string> mSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(Console.ReadLine());
            }

            for (int i = 0; i < m; i++)
            {
                mSet.Add(Console.ReadLine());
            }

            nSet.IntersectWith(mSet);
            Console.WriteLine(string.Join(" ", nSet));
        }
    }
}
