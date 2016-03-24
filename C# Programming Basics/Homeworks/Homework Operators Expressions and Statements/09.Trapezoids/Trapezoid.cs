using System;
class Trapezoid
{
    static void Main()
    {
        //Write an expression that calculates trapezoid's area by given sides a and b and height h. Examples:
        //a	        b	    h	    area	 
        //5	        7	    12	    72	
        //2	        1	    33	    49.5	
        //8.5	    4.3	    2.7	    17.28	
        //100	    200	    300	    45000	
        //0.222	    0.333	0.555	0.1540125	

        double aSide = double.Parse(Console.ReadLine());
        double bSide = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("The trapezoid area is: ({0} + {1}) * {2} / 2 = {3}", aSide, bSide, height,
                    (aSide + bSide) * height / 2);
    }
}

