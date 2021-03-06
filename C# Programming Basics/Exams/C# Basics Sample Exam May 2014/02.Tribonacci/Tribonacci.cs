﻿using System;
using System.Numerics;
class Tribonacci
{
    static void Main()
    {
        //The Tribonacci sequence is a sequence in which every next element is made by the sum of the previous three elements 
        //from the sequence.
        //Write a computer program that finds the Nth element of the Tribonacci sequence, if you are given 
        //the first three elements of the sequence and the number N. Mathematically said: with given T1, T2 and T3 – 
        //you must find Tn.
        //Input
        //•	The input data should be read from the console.
        //•	The values of the first three Tribonacci elements will be given on the first three input lines.
        //•	The number N will be on the fourth line. This is the number of the consecutive element of the sequence 
        //that must be found by your program.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data should be printed on the console.
        //•	At the only output line you must print the Nth element of the given Tribonacci sequence.
        //Constraints
        //•	The values of the first three elements of the sequence will be integers between -2 000 000 000 and 2 000 000 000.
        //•	The number N will be a positive integer between 1 and 15 000, inclusive.
        //•	Time limit: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output		Input	Output		Input	Output
        //1     3           2       335		    5       208691269
        //1                 3                   -1
        //1                 4                   2
        //4	                10                  33
        //Attribution: this work may contain portions from the "C# Part I" course by Telerik Academy under CC-BY-NC-SA license.

        BigInteger tribFirst =  BigInteger.Parse(Console.ReadLine());
        BigInteger tribSecond = BigInteger.Parse(Console.ReadLine());
        BigInteger tribThird = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        BigInteger tribN = new BigInteger(int.MinValue);
        if (n == 1)
        {
            Console.WriteLine(tribFirst);
        }
        else if (n == 2)
        {
            Console.WriteLine(tribSecond);
        }
        else if (n == 3)
        {
            Console.WriteLine(tribThird);
        }
        else
        {
            for (int i = 0; i <= n - 4; i++)
            {
                tribN = tribThird + tribSecond + tribFirst;
                tribFirst = tribSecond;
                tribSecond = tribThird;
                tribThird = tribN;
            }
            Console.WriteLine(tribN);
        }
    }
}

