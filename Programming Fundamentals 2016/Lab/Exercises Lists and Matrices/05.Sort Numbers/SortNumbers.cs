using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sort_Numbers
{
    public class SortNumbers
    {
        public static void Main()
        {
            List<string> list = Console.ReadLine().Split().ToList();
            list.Sort();
            list.Reverse();
            //list.Sort((a, b) => -b.CompareTo(a)); not work for negative numbers
            Console.WriteLine(string.Join(" <= ", list));
        }
    }
}
