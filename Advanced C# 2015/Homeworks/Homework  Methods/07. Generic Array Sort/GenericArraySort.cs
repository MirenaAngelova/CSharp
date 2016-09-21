using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
class GenericArraySort
{
    static void Main()
    {
        //Write a method which takes an array of any type and sorts it. Use bubble sort or selection sort 
        //(your own implementation). You may re-use your code from a previous homework and modify it. 
        //Use a generic method (read in Internet about generic methods in C#). Make sure that what you're trying to sort 
        //can be sorted – your method should work with numbers, strings, dates, etc., but not necessarily with custom 
        //classes like Student.

        CultureInfo invCul = CultureInfo.InvariantCulture;

        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

        Console.WriteLine(SortArray(numbers));
        Console.WriteLine(SortArray(strings));
        Console.WriteLine(SortArray(dates));

        Console.WriteLine(BubbleSort(numbers));
        Console.WriteLine(BubbleSort(strings));
        Console.WriteLine(BubbleSort(dates));


    }
    private static string SortArray<T>(IEnumerable<T> input)
    {
        List<T> temp = input.ToList();
        List<T> sorted = new List<T>();

        while (temp.Count != 0)
        {
            var t = temp.Min();
            sorted.Add(t);
            temp.Remove(t);
        }
        return PrintArray(sorted);
    }
    private static string BubbleSort<T>(T[] array) where T : System.IComparable<T>
    {
        bool swapped = false;

        do
        {
            swapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    T swap = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = swap;
                    swapped = true;
                }
            }

        } while (swapped == true);

        return PrintArray(array);
    }
    private static string PrintArray<T>(IEnumerable<T> array)
    {
        return string.Join(", ", array);
    }
}