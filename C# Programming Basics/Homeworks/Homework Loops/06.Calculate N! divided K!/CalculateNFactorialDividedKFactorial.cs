using System;
using System.Numerics;
class CalculateNFactorialDividedKFactorial
{
    static void Main()
    {
        //Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop. Examples:
        //n	k	n! / k!
        //5	2	60
        //6	5	6
        //8	3	6720

        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
            if (i <= k)
            {
                  factorialK *= i;
            }
        }
        //Console.WriteLine(factorialN);
        //Console.WriteLine(factorialK);
        Console.WriteLine(factorialN / factorialK);
    }
}

