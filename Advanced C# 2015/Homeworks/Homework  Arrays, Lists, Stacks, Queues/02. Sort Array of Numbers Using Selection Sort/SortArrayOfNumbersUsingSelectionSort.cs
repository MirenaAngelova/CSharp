using System;
class SortArrayUsingSelectionSort
{
    static void Main()
    {
        //Write a program to sort an array of numbers and then print them back on the console. 
        //The numbers should be entered from the console on a single line, separated by a space. 
        //Refer to the examples for problem 1.
        //Examples:
        //Input	                Output
        //6 5 4 10 -3 120 4 	-3 4 4 5 6 10 120
        //10 9 8	            8 9 10

        int[] intArray = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        for (int i = 0; i < intArray.Length - 1; i++)
        {
            for (int j = i + 1; j < intArray.Length; j++)
            {
                if (intArray[i] > intArray[j])
                {
                    int tempArray = intArray[i];
                    intArray[i] = intArray[j];
                    intArray[j] = tempArray;
                }
            }
        }

        foreach (var item in intArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}