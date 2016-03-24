using System;
class CirclePerimeterAndArea
{
    static void Main()
    {
        //Write a program that reads the radius r of a circle and prints its perimeter and area 
        //formatted with 2 digits after the decimal point. Examples:
        //r	   perimeter	 area
        //2	   12.57	     12.57
        //3.5  21.99	     38.48
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Enter radius \"r\": ");
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine("The circle perimeter is: 2 * \u03C0 = {0:f2}", 2 * Math.PI * radius);
        Console.WriteLine("The circle area is: \u03C0 * r * r = {0:f2}", Math.PI * radius * radius);
    }
}

