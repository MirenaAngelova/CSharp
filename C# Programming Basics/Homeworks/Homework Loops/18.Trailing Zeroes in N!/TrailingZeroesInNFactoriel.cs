using System;
class TrailingZeroesInNFactoriel
{
    static void Main()
    {
        //Write a program that calculates with how many zeroes the factorial of a given number n has at its end. 
        //Your program should work well for very big numbers, e.g. n=100000. Examples:
        //n	        trailing zeroes of n!	explaination
        //10	    2	                    3628800
        //20	    4	                    2432902008176640000
        //100000	24999	                think why

        int n = int.Parse(Console.ReadLine());
        int k = 0;
        int trailingZero = 0;
        while (Math.Pow(5, k) < n)
        {
            k++;
            trailingZero += n / (int)Math.Pow(5, k);
        }
        Console.WriteLine(trailingZero);
    }
}

