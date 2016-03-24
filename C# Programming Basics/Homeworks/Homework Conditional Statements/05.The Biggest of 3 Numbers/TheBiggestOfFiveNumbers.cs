using System;
class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        //Write a program that finds the biggest of five numbers by using only five if statements. Examples:
        //a     b	    c	    d	    e	    biggest
        //5	    2	    2	    4	    1	    5
        //-2	-22	    1	    0	    0	    1
        //-2	4	    3	    2	    0	    4
        //0	    -2.5	0	    5	    5	    5
        //-3	-0.5	-1.1	-2	    -0.1	-0.1

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());

        double max = double.MinValue;
        if ((a > b ) & (a > c) & (a > d) & (a > e))
        {
            max = a;
        }
        else if ((b > a) & (b > c) & (b > d) & (b > e))
        {
            max = b;

        }
        else if ((c > a) & (c > b) & (c > d) & (c > e))
        {
            max = c;
        }
        else if ((d > a) & (d > b) & (d > c) & (d > e))
        {
            max = d;
        }
        else
        {
            max = e;
        }
        Console.WriteLine(max);
    }
}

