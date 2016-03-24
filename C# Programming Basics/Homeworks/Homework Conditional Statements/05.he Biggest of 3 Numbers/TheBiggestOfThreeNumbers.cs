using System;
class TheBiggestOfThreeNumbers
{
    static void Main()
    {
        //Write a program that finds the biggest of three numbers. Examples:
        //a	    b	    c	    biggest
        //5	    2	    2	    5
        //-2	-2	    1	    1
        //-2	4	    3	    4
        //0	    -2.5	5	    5
        //-0.1	-0.5	-1.1	-0.1

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double max = 0;

        if (a >= b)
        {
            if (a >= c)
            {
                max = a;
            }
            else
            {
                max = c;
            }
        }
        else
        {
            if (b >= c)
            {
                max = b;
            }
        }
        Console.WriteLine(max);
    }
}

