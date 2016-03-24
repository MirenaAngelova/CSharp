using System;
class SumOfThreeNumbers
{
    static void Main()
    {
        //Write a program that reads 3 real numbers from the console and prints their sum. Examples:
        //a	   b	c	  sum
        //3	   4	11	  18
        //-2   0	3	  1
        //5.5  4.5	20.1  30.1

        Console.WriteLine("Enter real number a: ");
        double aReal = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter real number b: ");
        double bReal = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter real number c: ");
        double cReal = double.Parse(Console.ReadLine());

        Console.WriteLine("The sum of numbers is: {0} + {1} + {2} = {3}", aReal, bReal, cReal, aReal + bReal + cReal);
    }
}

