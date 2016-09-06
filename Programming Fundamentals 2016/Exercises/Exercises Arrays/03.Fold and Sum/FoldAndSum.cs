using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    public class FoldAndSum
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sum = new int[array.Length / 2];

            for (int i = 0; i < sum.Length / 2; i++)
            {
                sum[i] = array[array.Length/4 + i] + array[array.Length/4 - 1 - i];
                sum[sum.Length/2 + i] = array[array.Length/2 + i] + array[array.Length - 1 - i];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
