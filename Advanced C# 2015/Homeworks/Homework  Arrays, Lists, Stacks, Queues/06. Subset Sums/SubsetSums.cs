using System;
using System.Collections.Generic;
using System.Linq;
class SubsetSum
{
    static void Main()
    {
        //Write a program that reads from the console a number N and an array of integers given on a single line. 
        //Your task is to find all subsets within the array which have a sum equal to N and print them on the console 
        //(the order of printing is not important). Find only the unique subsets by filtering out repeating numbers first. 
        //In case there aren't any subsets with the desired sum, print "No matching subsets." Examples:
        //Input	                    Output
        //11                        0 + 11 = 11
        //0 11 1 10 5 6 3 4 7 2	    11 = 11
        //                          1 + 10 = 11
        //                          0 + 1 + 10 = 11
        //                          5 + 6 = 11
        //                          0 + 5 + 6 = 11
        //                          1 + 6 + 4 = 11
        //                          0 + 1 + 6 + 4 = 11
        //                          1 + 3 + 7 = 11
        //                          0 + 1 + 3 + 7 = 11
        //                          4 + 7 = 11
        //                          0 + 7 + 4 = 11
        //                          1 + 5 + 3 + 2 = 11
        //                          0 + 1 + 5 + 3 + 2 = 11
        //                          6 + 3 + 2 = 11
        //                          0 + 6 + 3 + 2 = 11
        //                          5 + 4 + 2 = 11
        //                          0 + 5 + 4 + 2 = 11
        //
        //0                         No matching subsets.
        //1 2 3 4 5	
        //-2                        -5 + 4 + -1 = -2
        //-5 4 92 0 928 1 -1 4	    -5 + 4 + 0 + -1 = -2

        int n = int.Parse(Console.ReadLine());
        List<int> integers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToList();

        //int intCount = 1 << integers.Count;
        
        //int counter = 0;
        //for (int i = 1; i < intCount; i++)
        //{
        //    int sum = 0;
        //    for (int j = 0; j < integers.Count; j++)
        //    {
        //        if ((i & (1 << integers.Count - 1 - j)) != 0)
        //        {
        //            sum += integers[j];
        //        }
        //    }
        //    if (sum == n)
        //    {
        //        counter++;
        //        List<int> equalN = new List<int>();
        //        for (int j = 0; j < integers.Count; j++)
        //        {
        //            if ((i & (1 << integers.Count - 1 - j)) != 0)
        //            {
        //                equalN.Add(integers[j]);
        //            }
        //        }
        //        Console.WriteLine(string.Join(" + ", equalN) + "= " + sum);
        //    }
        //}
        //if (counter == 0)
        //{
        //    Console.WriteLine("No matching subsets.");
        //}


        int subCount = (int)(Math.Pow(2, integers.Count));
        List<int> subsets = new List<int>();
        bool isMatching = false;

        for (int i = 1; i < subCount; i++)
        {
            subsets.Clear();
            for (int j = 0; j < integers.Count; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    subsets.Add(integers[j]);
                }
            }
            if (subsets.Sum() == n)
            {
                Console.WriteLine("{0} = {1}", string.Join(" + ", subsets), n);
                isMatching = true;
            }
        }
        if (!isMatching)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}



