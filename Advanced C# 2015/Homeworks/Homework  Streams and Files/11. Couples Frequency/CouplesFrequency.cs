using System;
using System.Collections.Generic;
using System.Linq;
class CouplesFrequency
{
    static void Main()
    {
        //Write a program that reads a sequence of n integers and calculates and prints the frequencies of all couples
        //of two consecutive numbers. For example, for the input sequence { 3 4 2 3 4 2 1 12 2 3 4 }, we have 10 couples
        //(6 distinct), shown on the right with their occurrence counts and frequencies (in percentage).
        //Couple	Occurrences	Percentage
        //3 4	    3 times	    30.00%
        //4 2	    2 times	    20.00%
        //2 3	    2 times	    20.00%
        //2 1	    1 times	    10.00%
        //1 12	    1 times	    10.00%
        //12 2	    1 times	    10.00%
        //Input
        //The input data should be read from the console. At the first line, we have the input sequence of integers, 
        //separated by a space.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print all distinct couples of two consecutive numbers (without duplicates) found in the input sequence
        //(from left to right) along with their frequency of appearance in the input sequence 
        //(in percentages, with two decimal digits, with traditional rounding). Use the format: "couple -> percentage"
        //(see the examples below). Beware of formatting!
        //Constraints
        //•	All input numbers will be integers in the range [-100 000 … 100 000].
        //•	The count of the numbers will be in the range [2..1000].
        //•	Time limit: 0.5 sec. Memory limit: 16 MB.
        //Examples
        //Input		                    Input		                        Input
        //3 4 2 3 4 2 1 12 2 3 4		5 10 5 10 10 5 5 10 5 10 10 5		10 20 10 10 10
        //Output		        Output		            Output
        //3 4 -> 30.00%         5 10 -> 36.36%          10 20 -> 25.00%
        //4 2 -> 20.00%         10 5 -> 36.36%          20 10 -> 25.00%
        //2 3 -> 20.00%         10 10 -> 18.18%         10 10 -> 50.00%
        //2 1 -> 10.00%         5 5 -> 9.09%		
        //1 12 -> 10.00%
        //12 2 -> 10.00%	
	

        string[] sequence = Console.ReadLine().Split();
        Dictionary<string, int> couples = new Dictionary<string, int>();

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            string couple = string.Join(" ", sequence.Skip(i).Take(2));

            if (!couples.ContainsKey(couple))
            {
                couples.Add(couple, 0);
            }
            couples[couple]++;
        }
        int distinctCouples = sequence.Length - 1;

        foreach (KeyValuePair<string, int> item in couples)
        {
            Console.WriteLine("{0} -> {1}", item.Key, ((double)item.Value / distinctCouples).ToString("0.00%"));
        }
    }
}