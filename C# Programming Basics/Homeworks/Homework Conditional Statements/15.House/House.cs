using System;
class House
{
    static void Main()
    {
        //Ivaylo decided he needs a new house. Since he is not a structural engineer yet, you have to help him construct 
        //the building from the ground zero.
        //The roof is a triangle. The walls are straight vertical lines. The base is a straight horizontal line. 
        //The roof, the walls and the base of the house it build of '*'. Everything else is filled with '.' 
        //(see the examples below to catch the idea).
        //You will be given an odd integer N, representing the width and the height of the house. 
        //The roof’s top starts from the center (N+1)/2 and forms a triangle with base of width N. 
        //The roof’s height is (N+1)/2. 
        //The distance between the roofs’ end point and the walls of the building is N/4, 
        //rounded down to an integer number. See the examples below to understand better these formulas.
        //Input
        //•	Input data is read from the console.
        //•	The number N stays alone at the first line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	You must print at the console a house of size N following the formulas above and the examples below.
        //Constraints
        //•	N will be an odd number between 5 and 49.
        //•	Time limit: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output		Input	Output		Input	Output
        //5	        ..*..       7	    ...*...     9	    ....*....
        //          .*.*.               ..*.*..             ...*.*...
        //          *****               .*...*.             ..*...*..
        //          .*.*.               *******             .*.....*.
        //          .***.               .*...*.             *********		
        //                              .*...*.             ..*...*..
        //                              .*****.             ..*...*..
        //                                                  ..*...*..
        //                                                  ..*****..

        int n = int.Parse(Console.ReadLine());
        int midPoint = n / 2;
        int count = 0;
        for (int i = 0; i < midPoint; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j == (midPoint - count) | j == (midPoint + count))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            count++;
        }
        Console.WriteLine(new string('*', n));
        for (int i = 0; i < midPoint - 1; i++)
        {
            Console.WriteLine(new string('.', n / 4) + "*" + new string('.', (n - ((n / 4) * 2) - 2)) + "*"
                        + new string('.', n / 4));
        }
        Console.WriteLine(new string('.', n / 4) + new string('*', n - ((n / 4) * 2)) + new string('.', n / 4));
    }
}

