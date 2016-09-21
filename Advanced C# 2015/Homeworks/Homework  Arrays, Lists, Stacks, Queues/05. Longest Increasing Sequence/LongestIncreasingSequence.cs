using System;
using System.Collections.Generic;
//using System.Linq;
class LongestIncreasingSequence
{
    static void Main()
    {
        //Write a program to find all increasing sequences inside an array of integers. 
        //The integers are given on a single line, separated by a space. Print the sequences in the order of 
        //their appearance in the input array, each at a single line. Separate the sequence elements by a space. 
        //Find also the longest increasing sequence and print it at the last line. If several sequences have 
        //the same longest length, print the left-most of them. Examples:
        //Input	                Output
        //2 3 4 1 50 2 3 4 5	2 3 4
        //                      1 50
        //                      2 3 4 5
        //                      Longest: 2 3 4 5
        //8 9 9 9 -1 5 2 3	    8 9
        //                      9
        //                      9
        //                      -1 5
        //                      2 3
        //                      Longest: 8 9
        //1 2 3 4 5 6 7 8 9	    1 2 3 4 5 6 7 8 9
        //                      Longest: 1 2 3 4 5 6 7 8 9
        //5 -1 10 20 3 4	    5
        //                      -1 10 20
        //                      3 4
        //                      Longest: -1 10 20
        //10 9 8 7 6 5 4 3 2 1	10
        //                      9
        //                      8
        //                      7
        //                      6
        //                      5
        //                      4
        //                      3
        //                      2
        //                      1
        //                      Longest: 10

        int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        List<int> temp = new List<int>();
        List<int> longestSeq = new List<int>();

        for (int i = 0, j = 1; i < sequence.Length; i++, j++)
        {
            temp.Add(sequence[i]);
            if (j < sequence.Length && sequence[i] < sequence[j])
            {
                continue;
            }
            else
            {
                if (temp.Count > longestSeq.Count)
                {
                    longestSeq.Clear();
                    longestSeq.AddRange(temp);
                    Console.WriteLine(string.Join(" ", temp));
                    temp.Clear();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", temp));
                    temp.Clear();
                }
            }
        }
        Console.WriteLine("Longest: " + string.Join(" ", longestSeq));
    }
}

