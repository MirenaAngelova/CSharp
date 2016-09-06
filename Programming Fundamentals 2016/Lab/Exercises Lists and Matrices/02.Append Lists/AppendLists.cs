using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Append_Lists
{
    public class AppendLists
    {
        static void Main()
        {
            List<string> list = Console.ReadLine().Split('|').ToList();

            list.Reverse();

            list = list.SelectMany(l => l.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)).ToList();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}