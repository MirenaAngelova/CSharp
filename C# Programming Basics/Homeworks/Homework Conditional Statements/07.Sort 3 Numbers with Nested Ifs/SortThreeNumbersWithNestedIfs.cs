using System;
class SortThreeNumbersWithNestedIfs
{
    static void Main()
    {
        //Write a program that enters 3 real numbers and prints them sorted in descending order. 
        //Use nested if statements. Don’t use arrays and the built-in sorting functionality. Examples:
        //a	    b	    c	    result
        //5	    1	    2	    5 2 1
        //-2	-2	    1	    1 -2 -2
        //-2	4	    3	    4 3 -2
        //0	    -2.5	5	    5 0 -2.5
        //-1.1	-0.5	-0.1	-0.1 -0.5 -1.1
        //10	20	    30	    30 20 10
        //1	    1	    1	    1 1 1

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double max = 0;
        double middle = 0;
        double min = 0;
        if (a >= b)
        {
            if(a >= c)
            {
                max = a;
                if (b >= c)
                {
                    middle = b;
                    min = c;
                }
                else
                {
                    middle = c;
                    min = b;
                }
            }
            else
            {
                max = c;
                middle = a;
                min = b;
            }
        }
        else
        {
            if (b >= c)
            {
                max = b;
                if (a >= c)
                {
                    middle = a;
                    min = c;
                }
                else
                {
                    middle = c;
                    min = a;
                }
            }
            else
            {
                max = c;
                middle = b;
                min = a;
            }
        }
        Console.WriteLine(max + " " + middle + " " + min);
    }
}

