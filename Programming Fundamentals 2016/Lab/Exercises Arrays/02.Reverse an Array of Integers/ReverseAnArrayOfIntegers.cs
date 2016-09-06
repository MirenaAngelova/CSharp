using System;

namespace _02.Reverse_an_Array_of_Integers
{
    public class ReverseAnArrayOfIntegers
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
