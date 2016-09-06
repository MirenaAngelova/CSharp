using System;
using System.Linq;

namespace _08.Most_Frequent_Number
{
    public class MostFrequentNumber
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool[] used = new bool[array.Length];
            // for unsorted arrays
            // Array.Sort(array);

            int index = 0;
            int len = 1;
            int bestLen = 1;
            int mostFrequentNumber = int.MinValue;
            for (int position = 1; position < array.Length; position++)
            {
                used[index] = true;
                int returnToPosition = position;
                while (position < array.Length)
                {
                    bool notUsed = !used[position];
                    bool isEqual = array[index] == array[position];
                    if ( notUsed && isEqual)
                    {
                        used[position] = true;
                        len++;
                    }

                    position++;
                }

                if (len > bestLen)
                {
                    bestLen = len;
                    mostFrequentNumber = array[index];
                }

                index++;
                position = returnToPosition;
                len = 1;
            }


            Console.WriteLine(
                $"The number {mostFrequentNumber} is the most frequent (occurs {bestLen} times)");
        }
    }
}
