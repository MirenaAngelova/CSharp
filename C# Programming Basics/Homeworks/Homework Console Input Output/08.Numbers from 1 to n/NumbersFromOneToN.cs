using System;

class NumbersFromOneToN
{
    static void Main()
    {
        //Write a program that reads an integer number n from the console and prints all the numbers 
        //in the interval [1..n], each on a single line. Note that you may need to use a for-loop. Examples:
        //numbers	sum		numbers	sum		numbers	sum
        //3	        1       5       1       1	    1
        //          2               2
        //          3               3			
        //                          4
        //                          5	
        //
        //	

        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);   
        }
    }
}

