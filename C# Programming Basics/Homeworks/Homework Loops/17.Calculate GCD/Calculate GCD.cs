using System;
class Program
{
    static void Main()
    {
        //Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. 
        //Use the Euclidean algorithm (find it in Internet). Examples:
        //a	    b	    GCD(a, b)
        //3	    2	    1
        //60	40	    20
        //5	    -15 	5

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int quotient = 0;
        int remainder = 1;
        while (remainder != 0)
        {
            remainder = a % b;
            quotient = a / b;
            a = b;
            b = remainder;
        }
        Console.WriteLine(a);
    }
}

