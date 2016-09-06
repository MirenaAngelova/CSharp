using System;
using System.Linq;

namespace _04.Last_K_Numbers_Sums_Sequence
{
    public class LastKNumbersSumsSequence
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] sequence = new long[n];
            sequence[0] = 1;
            for (int i = 1; i < n; i++)
            {
                //long sum = 0;
                //for (int j = i - k; j <= i - 1; j++)
                //{
                //    if (j >= 0)
                //    {
                //        sum += sequence[j];
                //    }
                //}

                //sequence[i] = sum;

                sequence[i] = sequence.Take(i).Reverse().Take(k).Sum();
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
