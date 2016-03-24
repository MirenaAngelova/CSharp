using System;
class Rectangles
{
    static void Main()
    {
        //Write an expression that calculates rectangle’s perimeter and area by given width and height. Examples:
        //width	height	perimeter	area
        //3	    4	    14	        12
        //2.5	3	    11	        7.5
        //5	    5	    20	        25

        float width = float.Parse(Console.ReadLine());
        float height = float.Parse(Console.ReadLine());
        Console.WriteLine("The perimeter is: {0}", (width + height) * 2);
        Console.WriteLine("The area is: {0}", width * height);
    }
}
