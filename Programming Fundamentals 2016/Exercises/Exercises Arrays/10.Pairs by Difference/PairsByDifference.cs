using System;
using System.Linq;

namespace _10.Pairs_by_Difference
{
    public class PairsByDifference
    {
        public static void Main()
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            int len = 0;
            for (int first = 0; first < sequence.Length; first++)
            {
                for (int second = first + 1; second < sequence.Length; second++)
                {
                    if (Math.Abs(sequence[first] - sequence[second]) == difference ||
                        Math.Abs(sequence[second] - sequence[first]) == difference)
                    {
                        len++;
                    }
                }
            }

            Console.WriteLine(len);
        }
    }
}
