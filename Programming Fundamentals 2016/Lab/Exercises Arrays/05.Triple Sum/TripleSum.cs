using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Triple_Sum
{
    public class TripleSum
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            bool noExistSuchTriples = true;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    sum = array[i] + array[j];
                    if (array.Contains(sum))
                    {
                        Console.WriteLine($"{array[i]} + {array[j]} == {sum}");
                        noExistSuchTriples = false;
                    }
                }
            }

            if (noExistSuchTriples)
            {
                Console.WriteLine("No");
            }
        }
    }
}
