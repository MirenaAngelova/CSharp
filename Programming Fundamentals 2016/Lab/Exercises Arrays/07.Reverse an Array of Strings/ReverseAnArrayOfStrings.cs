using System;

namespace _07.Reverse_an_Array_of_Strings
{
    public class ReverseAnArrayOfStrings
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split();

            for (int i = 0; i < array.Length/2; i++)
            {
                //string temp = array[i];
                //array[i] = array[array.Length - 1 - i];
                //array[array.Length - 1 - i] = temp;

                Swap(ref array[i], ref array[array.Length - 1 - i]);
            }

            Console.Write(string.Join(" ", array));
            Console.WriteLine();
        }

        private static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }
    }
}
