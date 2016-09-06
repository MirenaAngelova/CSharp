using System;
using System.Linq;

namespace _08.Sum_Arrays
{
    public class SumArrays
    {
        public static void Main()
        {
            int[] arrayFirst = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arraySecond = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int len = Math.Max(arrayFirst.Length, arraySecond.Length);
            int lenFirst = arrayFirst.Length;
            int lenSecond = arraySecond.Length;

            int[] sum = new int[len];
            for (int i = 0; i < len; i++)
            {
                sum[i] = arrayFirst[i%lenFirst] + arraySecond[i%lenSecond];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
