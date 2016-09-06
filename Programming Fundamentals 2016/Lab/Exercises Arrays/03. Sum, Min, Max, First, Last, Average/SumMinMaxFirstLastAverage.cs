using System;
using System.Linq;

namespace _03.Sum__Min__Max__First__Last__Average
{
    public class SumMinMaxFirstLastAverage
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {array.Sum()}");
            Console.WriteLine($"Min = {array.Min()}");
            Console.WriteLine($"Max = {array.Max()}");
            Console.WriteLine($"First = {array.First()}");
            Console.WriteLine($"Last = {array.Last()}");
            Console.WriteLine($"Average = {array.Average()}");
        }
    }
}
