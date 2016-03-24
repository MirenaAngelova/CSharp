using System;
class RandomNumbersInGivenRange
{
    static void Main()
    {
        //Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers in the range 
        //[min...max]. Examples:
        //n	    min	    max	    random numbers
        //5	    0	    1	    1 0 0 1 1
        //10	10	    15	    12 14 12 15 10 12 14 13 13 11
        //Note that the above output is just an example. Due to randomness, your program most probably will produce
        //different results.

        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        Random randomNum = new Random();
        for (int i = 0; i < n; i++)
        {
            int randomN = randomNum.Next(min, max + 1);
            Console.Write("{0} ", randomN);
        }
        Console.WriteLine();
    }
}


