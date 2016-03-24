using System;
using System.Collections.Generic;
using System.Numerics;
class FibonacciNumbers
{
    static void Main()
    {
        //Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
        //(at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. 
        //Note that you may need to learn how to use loops. Examples:
        //n	   comments
        //1	   0
        //3	   0 1 1
        //10   0 1 1 2 3 5 8 13 21 34

        BigInteger f0 = 0;
        BigInteger f1 = 1;
        BigInteger fN;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            fN = f0;
            f0 = f1;
            f1 = fN + f0;
            Console.Write("{0}, ", fN);
        }
        Console.WriteLine();
    }
}

