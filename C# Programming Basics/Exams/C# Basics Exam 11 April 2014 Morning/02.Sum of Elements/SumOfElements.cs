using System;
using System.Collections.Generic;
using System.Linq;
class SumOfElements
{
    static void Main()
    {
        //You are given n numbers. Find an element that is equal to the sum of all of the other elements.
        //Input
        //Input data should be read from the console.
        //•	At the only line in the input a sequence of integers stays (numbers separated one from another by a space).
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console. At the only line of the output print the result.
        //•	Print "Yes, sum=…" if there is an element that is equal to the sum of all other elements, along with this sum.
        //•	Print "No, diff=…" if there is no element that is equal to the sum of all other elements. 
        //Print also the minimum possible difference between an element from the sequence and the sum of all other elements 
        //(always a positive number).
        //Constraints
        //•	All input numbers are integers in the range [0 … 2 000 000 000].
        //•	The count n of the input integers is in the range [2 ... 1 000].
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	            Output	        Comments		                Input	Output
        //3 4 1 1 2 12 1	Yes, sum=12	    3 + 4 + 1 + 2 + 1 + 1 = 12		6 1 2 3	Yes, sum=6
        //
        //Input	    Output		    Input	Output		    Input	Output		    Input	Output
        //1 1 10	No, diff=8		5 5 1	No, diff=1		1 1 1	No, diff=1		0 0	Yes, sum=0


        //long[] n = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        //long diff = Math.Abs((n.Sum() - n.Max()) - n.Max());
        //if (diff == 0)
        //{
        //    Console.WriteLine("Yes, sum={0}", n.Max());
        //}
        //else
        //{
        //    Console.WriteLine("No, diff={0}", diff);
        //}


        //int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //List<long> sum = new List<long>();
        //for (int i = 0; i < sequence.Length; i++)
        //{
        //    sum.Add(sequence[i]);
        //}
        //if (sum.Max() == sum.Sum() - sum.Max())
        //{
        //    Console.WriteLine("Yes, sum={0}", sum.Max());
        //}
        //else
        //{
        //    Console.WriteLine("No, diff={0}", Math.Abs(sum.Max() - (sum.Sum() - sum.Max())));
        //}

        string[] n = Console.ReadLine().Split(' ');
        long[] numbers = new long[n.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(n[i]);
        }
        long diff = Math.Abs(numbers.Max() - (numbers.Sum() - numbers.Max()));
        if (diff == 0)
        {
            Console.WriteLine("Yes, sum={0}", numbers.Max());
        }
        else
        {
            Console.WriteLine("No, diff={0}", diff);
        }

    }
}

