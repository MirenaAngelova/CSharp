using System;
using System.Linq;

namespace _06.Max_Sequence_of_Equal_Elements
{
    public class MaxSequenceOfEqualElements
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int len = 1;
            int bestLen = 1;
            int bestStart = 0;
            for (int position = 1; position < array.Length; position++)
            {
                while (position < array.Length && array[start] == array[position])
                {
                    len++;
                    position++;
                }

                if (len > bestLen)
                {
                    bestLen = len;
                    bestStart = start;
                }

                start = position;
                len = 1;
            }
            //0 1 1 5 2 2 6 3 3
            //0 1 2 3 4 5 6 7 8
            for (int i = bestStart; i < bestStart + bestLen; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
