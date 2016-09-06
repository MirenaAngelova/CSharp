using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Sum_Adjacent_Equal_Numbers
{
    public class SumAdjacentEqualNumbers
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            // 32 16 8 4 2 1 1
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    list[i] += list[i + 1];
                    list.RemoveAt(i + 1);
                    if (i == 0)
                    {
                        i--;
                    }
                    else
                    {
                        i -= 2;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
