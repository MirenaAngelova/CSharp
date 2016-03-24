using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        //In combinatorics, the Catalan numbers are calculated by the following formula:
        //
        //Write a program to calculate the nth Catalan number by given n (1 < n < 100). Examples:
        //n	    Catalan(n)
        //0	    1
        //5	    42
        //10	16796
        //15	9694845

        int n = int.Parse(Console.ReadLine());
        BigInteger factorial2N = 1;
        BigInteger factorialN = 1;
        BigInteger factorialN1 = 1;
        for (int i = 1; i <= 2 * n; i++)
        {
            factorial2N *= i;
            if (i <= n)
            {
                factorialN *= i;
            }
        }
        for (int i = 1; i <= n + 1; i++)
        {
            factorialN1 *= i;
        }
        Console.WriteLine(factorial2N / (factorialN1 * factorialN));
    }
}

