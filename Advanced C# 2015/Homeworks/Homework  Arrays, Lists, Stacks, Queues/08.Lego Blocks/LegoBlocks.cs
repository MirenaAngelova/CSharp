using System;
using System.Collections.Generic;
using System.Linq;
class LegoBlocks
{
    static void Main()
    {
        //You are given two jagged arrays. Each array represents a Lego block containing integers. Your task is first 
        //to reverse the second jagged array and then check if it would fit perfectly in the first jagged array.
        //1 1 1 1 1 1    1 1           1 1     1 1 1 1 1 1 1 1
        //2 1 1 3        2 2 2 3   3 2 2 2     2 1 1 3 3 2 2 2
        //2 1 1 2 3      3 3 3       3 3 3     2 1 1 2 3 3 3 3
        //7 7 7 5 3 2    4 4           4 4     7 7 7 5 3 2 4 4
        //The picture above shows exactly what fitting arrays mean. If the arrays fit perfectly you should print out 
        //the newly made rectangular matrix. If the arrays do not match (they do not form a rectangular matrix) 
        //you should print out the number of cells in the first array and in the second array combined. 
        //The examples below should help you understand the assignment better.
        //Input
        //The first line of the input comes as an integer number n saying how many rows are there in both arrays. 
        //Then you have 2 * n lines of numbers separated by whitespace(s). The first n lines are the rows of the first jagged
        //array; the next n lines are the rows of the second jagged array. There might be leading and/or trailing
        //whitespace(s).
        //Output
        //You should print out the combined matrix in the format:
        //[elem, elem, …, elem]
        //[elem, elem, …, elem]
        //[elem, elem, …, elem]
        //If the two arrays do not fit you should print out : The total number of cells is: count
        //Constraints
        //•	The number n will be in the range [2 … 10].
        //•	Time limit: 0.3 sec. Memory limit: 16 MB.
        //Examples
        //Input	            Output
        //2                 [1, 1, 1, 1, 1, 1, 1, 1]
        //1 1 1 1 1 1       [2, 1, 1, 3, 3, 2, 2, 2]
        //2 1 1 3
        //1 1
        //2 2 2 3	
        //
        //2                 The total number of cells is: 14
        //1 1 1 1 1
        //1 1 1
        //1
        //1 1 1 1 1	

        int n = int.Parse(Console.ReadLine());
        List<List<int>> legoBlocks = new List<List<int>>();

        for (int i = 0; i < 2 * n; i++)
        {
            List<int> arrays = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            if (i >= n)
            {
                arrays.Reverse();
            }
            legoBlocks.Add(arrays);
        }
        int firstLength = legoBlocks[0].Count + legoBlocks[n].Count;
        for (int i = 1; i < n; i++)
        {
            if (legoBlocks[i].Count + legoBlocks[i + n].Count != firstLength)
            {
                int counter = 0;
                foreach (var legoBlock in legoBlocks)
                {
                    counter += legoBlock.Count;
                }
                Console.WriteLine("The total number of cells is: {0}", counter);
                return;
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("[" + string.Join(", ", legoBlocks[i]) + ", " + string.Join(", ", legoBlocks[i + n]) + "]");
        }
    }
}