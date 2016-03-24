using System;
using System.Collections.Generic;
using System.Linq;
class Pairs
{
    static void Main()
    {
        //You are given 2*N elements (even number of integer numbers). The first and the second element form a pair, 
        //the third and the fourth element form a pair as well, etc. Each pair has a value, calculated as the sum 
        //of its two elements. Your task is to write a program to check whether all pairs have the same value or 
        //print the max difference between two consecutive values.
        //Input
        //You are given at the console even number of integers, all in a single line, separated by a space.
        //Output
        //The output is single line, printed at the console.
        //•	In case all pairs have the same value, print "Yes, value=…" and the value.
        //•	Otherwise, print "No, maxdiff=…" and the maximal difference between two consecutive values, 
        //always a positive integer.
        //Constraints
        //•	All input values will be integers in the range [-1000…1000] inclusive.
        //•	The count of elements is even number in the range [2…1000] inclusive.
        //•	Allowed work time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	            Output	        Comments
        //1 2 0 3 4 -1	    Yes, value=3	values = {3, 3, 3} --> equal values
        //1 2 2 2	        No, maxdiff=1	values = {3, 4}, different values --> max difference = 4-3 = 1
        //1 1 3 1 2 2 0 0	No, maxdiff=4	values = {2, 4, 4, 0}, differences = {2, 0, 4}, max difference = 4
        //5 5	            Yes, value=10	values = {10} --> single value --> equal values
        //-1 0 0 -1	        Yes, value=-1	values = {-1, -1}, equal values

        int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        List<int> sum = new List<int>();
        List<int> diff = new List<int>();
        for (int i = 0; i < n.Length; i += 2)
        {
            sum.Add(n[i] + n[i + 1]);
        }
        for (int i = 1; i < sum.Count; i++)
        {
            diff.Add(Math.Abs(sum[i] - sum[i - 1]));
        }
        if (sum.All(x => x == sum[0]))
        {
            Console.WriteLine("Yes, value={0}", sum[0]);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", diff.Max());
        }
    }
}

