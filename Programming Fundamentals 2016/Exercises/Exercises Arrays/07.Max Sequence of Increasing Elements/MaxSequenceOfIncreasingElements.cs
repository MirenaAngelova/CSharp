using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Increasing_Elements
{
    public class MaxSequenceOfIncreasingElements
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int len = 1;
            int start = 0;
            
            int bestLength = 1;
            int bestStart = 0;

            int[] bestStartBestLength = FindBestLengthAndStart(array, len, start, bestStart, bestLength);
            bestStart = bestStartBestLength[0];
            bestLength = bestStartBestLength[1];
            PrintLongestIncreasingsequence(array, bestStart, bestLength);
           
        }

        private static void PrintLongestIncreasingsequence(int[] array, int bestStart, int bestLength)
        {
            for (int i = bestStart; i < bestStart + bestLength; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        private static int[] FindBestLengthAndStart(
            int[] array, int len, int start, int bestStart, int bestLength)
        {
            int[] bestStartBestLength = new int[2];
            for (int position = 1; position < array.Length; position++)
            {
                int index = start;
                while (position < array.Length && array[index] < array[position])
                {
                    len++;
                    index++;
                    position++;
                    
                }

                if (len > bestLength)
                {
                    bestLength = len;
                    bestStart = start;
                }

                start = position;
                len = 1;
            }

            bestStartBestLength[0] = bestStart;
            bestStartBestLength[1] = bestLength;

            return bestStartBestLength;
        }
    }
}
