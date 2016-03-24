using System;

class InsideTheBuilding
{
    static void Main()
    {
        //In Absurdistan the buildings look like the figure on the right. They consist of 6 blocks of size h * h. 
        //Their bottom-left corner is located at the coordinates (0, 0). See the figure (for h = 2) to get a better idea.
        //Write a program that enters a size h and 5 points {x1, y1}, {x2, y2}, {x3, y3}, {x4, y4}, and {x5, y5} 
        //and prints for each of the points whether it is inside or outside of the building. 
        //Points at the building's border, like {0, 0}, are considered inside.
        //Input
        //The input data should be read from the console.
        //•	At the first line an integer number h specifying the size of the building will be given.
        //•	At the next 10 lines the numbers x1, y1, x2, y2, x3, y3, x4, y4, x5, y5 are given.
        //The input data will always be valid and in the format described. There is no need to check it explicitly
        //Output
        //The output should be printed on the console. It should consist of exactly 5 lines. 
        //At each line print either "inside" or "outside" depending of where each of the 5 input points are located.
        //Constraints
        //•	All numbers in the input will be integers in the range [-1000 … 1000].
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	 Output    Comments		Input	Output	 Comments
        //2      outside                15      inside
        //3      outside                29      outside
        //10     inside                 38      inside
        //0      inside                 37      outside
        //6      inside                 19      outside	 
        //2                             30
        //2                             0
        //3                             -4
        //1                             7
        //6                             13
        //0	                            57	

        int h = int.Parse(Console.ReadLine());
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());
        int x3 = int.Parse(Console.ReadLine());
        int y3 = int.Parse(Console.ReadLine());
        int x4 = int.Parse(Console.ReadLine());
        int y4 = int.Parse(Console.ReadLine());
        int x5 = int.Parse(Console.ReadLine());
        int y5 = int.Parse(Console.ReadLine());

        Console.WriteLine(IsInside(x1, y1, h));
        Console.WriteLine(IsInside(x2, y2, h));
        Console.WriteLine(IsInside(x3, y3, h));
        Console.WriteLine(IsInside(x4, y4, h));
        Console.WriteLine(IsInside(x5, y5, h));

    }

    private static string IsInside (int x, int y, int h)
    {
        bool isBottom = (x >= 0) & (x <= (3 * h)) & (y >= 0) & (y <= h);
        bool isTop = (x >= h) & (x <= (2 * h)) & (y >= h) & (y <= (4 * h));
        bool isInside = isBottom | isTop;
        string result = isInside ? "inside" : "outside";
        return result;
    }
}

