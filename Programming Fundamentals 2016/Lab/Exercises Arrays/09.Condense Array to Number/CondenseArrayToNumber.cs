using System;
using System.Linq;

namespace _09.Condense_Array_to_Number
{
    public class CondenseArrayToNumber
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = array.Length - 1;
            while (index >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    array[i] = array[i] + array[i + 1];
                }

                index--;
            }

            Console.WriteLine(array[0]);
        }
    }
}
