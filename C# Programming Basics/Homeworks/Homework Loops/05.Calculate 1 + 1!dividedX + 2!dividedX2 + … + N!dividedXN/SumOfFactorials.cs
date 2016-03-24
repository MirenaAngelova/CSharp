using System;
class SumOfFactorials
{
    static void Main()
    {
        //Write a program that, for a given two integer numbers n and x, calculates 
        //the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn. Use only one loop. 
        //Print the result with 5 digits after the decimal point.
        //n	x	S
        //3	2	2.75000
        //4	3	2.07407
        //5	-4	0.75781

        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int factorial = 1;
        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += factorial / Math.Pow(x, i);
        }
        Console.WriteLine("{0:f5}", sum);


    }
}

