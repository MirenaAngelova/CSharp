using System;
class PointInACircle
{
    static void Main()
    {
        //Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2). Examples:
        //x	    y	    inside	 
        //0	    1	    true	
        //-2    0	    true	
        //-1    2	    false	
        //1.5   -1	    true	
        //-1.5  -1.5    false	
        //100   -30	    false	
        //0	     0	    true
        //0.2	-0.8	true
        //0.9	-1.93	false
        //1	     1.655	true

        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double z = Math.Sqrt(x * x + y * y);
        bool isPoint = true;
        
        if (z <= 2)
        {
            Console.WriteLine(isPoint);
        }
        else
        {
            Console.WriteLine(!isPoint);
        }

    }
}

