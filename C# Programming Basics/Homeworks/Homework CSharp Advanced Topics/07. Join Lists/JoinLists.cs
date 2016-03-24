using System;
using System.Linq;
class JoinLists
{
    static void Main()
    {
        //Write a program that takes as input two lists of integers and joins them. The result should hold all numbers 
        //from the first list, and all numbers from the second list, without repeating numbers, and arranged in 
        //increasing order. The input and output lists are given as integers, separated by a space,
        //each list at a separate line. Examples:
        //Input	                Output
        //20 40 10 10 30 80     10 20 25 30 40 80
        //25 20 40 30 10
	    //
        //5 4 3 2 1             1 2 3 4 5 6
        //6 3 2	   
        //
        //1                 	1
        //1

        string[] firstListStr = Console.ReadLine().Split();
        int[] firstList = Array.ConvertAll<string, int>(firstListStr, int.Parse);
        string[] secondListStr = Console.ReadLine().Split();
        int[] secondList = Array.ConvertAll<string, int>(secondListStr, int.Parse);

        var outputList = firstList.Union(secondList).Distinct();
        var sortOutput = from items in outputList
                         orderby items
                         select items;

        foreach (var item in sortOutput)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();                 
    }
}

