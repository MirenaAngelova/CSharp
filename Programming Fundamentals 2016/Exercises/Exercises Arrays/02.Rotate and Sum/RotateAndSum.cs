using System;
using System.Linq;

namespace _02.Rotate_and_Sum
{
    public class RotateAndSum
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotateTimes = int.Parse(Console.ReadLine());
            long[] sum = new long[array.Length];
            for (int i = 1; i <= rotateTimes; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int length = array.Length;
                    sum[j] += array[(length - i%length + j)%length];
                }
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
