using System;
using System.Collections.Generic;
class LongestNonDecreasingSusequence
{
    static void Main()
    {
        //Write a program that reads a sequence of integers and finds in it the longest non-decreasing subsequence. 
        //In other words, you should remove a minimal number of numbers from the starting sequence, 
        //so that the resulting sequence is non-decreasing. In case of several longest non-decreasing sequences, 
        //print the leftmost of them. The input and output should consist of a single line, holding integer numbers 
        //separated by a space. Examples:
        //Input	                                Output
        //1	                                    1
        //7 3 5 8 -1 6 7	                    3 5 6 7 
        //1 1 1 2 2 2	                        1 1 1
        //1 1 1 3 3 3 2 2 2 2	                2 2 2 2
        //11 12 13 3 14 4 15 5 6 7 8 7 16 9 8	3 4 5 6 7 8 9
        //
        //7 3 5 8 -1 6 7       1 1 1 2 2 2      1 1 1 3 3 3 2 2 2 2      11 12 13 3 14 4 15 5 6 7 8 7 16 9 8
        //7     8              1 1 1            1 1 1                    11 12 13   14   15           16
        //  3 5      6 7             2 2 2            3 3 3                       3    4    5 6 7 8      9
        //        -1                                        2 2 2 2                                 7      8

        
        string[] array = Console.ReadLine().Split();
        int[] sequence = new int[array.Length];
        int num = 0;
        List<int> numArray = new List<int>();
        sequence = Array.ConvertAll<string, int>(array, int.Parse);
        numArray.Add(sequence[0]);
        int nums = sequence[0];
        int i = 1;
        for (; i < sequence.Length; i++)
        {
            num = sequence[i - 1];
            if (num > sequence[i])
            {
                nums = num;
                num = sequence[i];
                numArray.Clear();
                numArray.Add(num);
                break;
            }
            else if (num == sequence[i] & nums == sequence[i])
            {
                nums = num;
                numArray.Add(sequence[i]);
            }
        }
        for (i++; i < sequence.Length; i++)
        {
            if ((sequence[i] >= num) & (sequence[i] <= nums))
            {
                numArray.Add(sequence[i]);
                num = sequence[i];
            }
        }
        foreach (var item in numArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

