using System;
class InsideOutsidePoint
{
    static void Main()
    {
        //Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) 
        //and out of the rectangle R(top=1, left=-1, width=6, height=2). Examples:
        //x	    y	    inside K & outside of R	 
        //1	    2	    yes	
        //2.5	2	    no
        //0	    1	    no
        //2.5	1	    no
        //2	    0	    no
        //4	    0	    no
        //2.5	1.5	    no
        //2	    1.5	    yes
        //1	    2.5	    yes
        //-100	-100    no

        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double z = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));

        if (x >= (-0.5) & x <= 2.5 & y > 1 & y <= 2.5 & z <= 1.5) //y > 1, because of "0  1  no"
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

