using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    public class PeriodicTable
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> periodicTable = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split();
                foreach (var chemicalCompound in chemicalCompounds)
                {
                    periodicTable.Add(chemicalCompound);
                }
                
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
