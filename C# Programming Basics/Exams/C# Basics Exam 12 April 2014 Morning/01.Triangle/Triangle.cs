using System;
class Triangle
{
    static void Main()
    {
        //You are given a two-dimensional Cartesian coordinate system and three points A, B, C with coordinates:
        //A(Ax, Ay), B(Bx,  By), C(Cx, Cy). Write a program to check if these three points can form a triangle. 
        //Then calculate the area of this triangle. To find the distance between two points with 
        //the coordinates (x1, y1) and (x2, y2) use the formula:
        //D = Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        //You can use the inequalities of a triangle to check whether three segments a, b and c can form a triangle:
        //a + b > c; b + c > a; a + c > b;
        //To calculate the area you can use Heron`s formula (a method for calculating the area of a triangle 
        //when you know the lengths of all three sides). Let a, b, c be the lengths of the sides of a triangle. Thus:
        //Area = Sqrt(p * (p - a) * (p - b) * (p - c)), where p is half the perimeter p = (a + b + c) / 2;
        //Input
        //The input data comes from the console. It consists of exactly 6 lines holding the coordinates of the three points: 
        //Ax-coordinate, Ay-coordinate, Bx-coordinate, By-coordinate, Cx-coordinate and Cy-coordinate. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data should be printed on the console and must contain two lines. 
        //•	First line: If the given points can form a triangle you must print the message “Yes”, otherwise “No”.
        //•	Second line: If the given points can form a triangle you must print the area of the triangle rounded 
        //to two decimal places (see the examples), otherwise you must print the distance between point A and point B. 
        //Use "." as decimal separator.
        //Constraints
        //•	The coordinate X is integer in the range [-10000… 10000] inclusive.
        //•	The coordinate Y is integer in the range [-10000… 10000] inclusive
        //•	Allowed work time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	Comments		Input	Output	Comments
        //2     No                      2       Yes
        //2     2.83                    3       9.00
        //0                             0
        //0                             -1
        //1                             4	
        //1                             -2	
        //                              
        //           

        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());
        double a = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        double b = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
        double c = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));

        if (((a + b) > c) & ((b + c) > a) & ((a + c) > b))
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Yes \n{0:f2}", area);
        }
        else
        {
            Console.WriteLine("No \n{0:f2}", a);
        }

    }
}

