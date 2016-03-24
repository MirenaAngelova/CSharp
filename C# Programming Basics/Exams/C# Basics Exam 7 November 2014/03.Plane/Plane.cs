using System;
class Plane
{
    static void Main()
    {
        //You will be given an integer N. The width of the rocklq is (3*N). 
        //The height of the plane is ((N * 3) – (N / 2)) and the width is (N * 3). 
        //Check the examples below to understand your task better.
        //Input
        //Input data is read from the console.
        //•	The number N stays alone at the first line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	You must print at the console a picture of size N following the formulas above and the examples below.
        //Constraints
        //•	N will be a number between 5 and 31 and will be an odd number.
        //•	Time limit: 0.25 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output		        Input	Output		                Input	Output
        //5	        .......*.......     7 	    ..........*..........       9	    .............*............. 
        //          ......*.*......             .........*.*.........               ............*.*............
        //          .....*...*.....             ........*...*........               ...........*...*...........
        //          ....*.....*....             .......*.....*.......               ..........*.....*..........
        //          ...*.......*...             ......*.......*......               .........*.......*.........
        //          .*...........*.             .....*.........*.....               ........*.........*........
        //          *...*.....*...*             ...*.............*...               .......*...........*.......
        //          *.*.*.....*.*.*             .*.................*.               .....*...............*.....
        //          ....*.....*....             *.....*.......*.....*               ...*...................*...
        //          ...*.......*...             *...*.*.......*.*...*               .*.......................*.
        //          ..*.........*..             *.*...*.......*...*.*               *.......*.........*.......*
        //          .*...........*.             ......*.......*......               *.....*.*.........*.*.....*
        //          ***************             .....*.........*.....               *...*...*.........*...*...*		
        //                                      ....*...........*....               *.*.....*.........*.....*.*     
        //                                      ...*.............*...               ........*.........*........     
        //                                      ..*...............*..               .......*...........*.......     
        //                                      .*.................*.               ......*.............*......     
        //                                      *********************               .....*...............*.....     
        //                                                                          ....*.................*....
        //                                                                          ...*...................*...
        //                                                                          ..*.....................*..
        //                                                                          .*.......................*.
        //                                                                          ***************************

        int n = int.Parse(Console.ReadLine());
        int midPoint = (3 * n ) / 2;
        int count = 0;
        for (int i = 0; i < n + 1; i++)
        {
            for (int j = 0; j < 3 * n; j++)
            {
                if ((j == midPoint - count) | ((j == midPoint + count)))
                {
                    Console.Write("*");
                } 
                else
	            {
                    Console.Write(".");
	            }
            }
            Console.WriteLine();
            if (i < (n / 2) + 2)
            {
                count++;
            }
            else
            {
                count += 2;
            }
            
            
        }
        count = n / 2 + 1;
        for (int i = 0; i < n / 2; i++)
        {
            
            for (int j = 0; j < 3 * n; j++)
            {
               
                if ((j == 0) | (j == n - 1) | (j == 2 * n) | (j == 3 * n - 1) | (j == midPoint - count) | (j == midPoint + count))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            count += 2;
            Console.WriteLine();
        }
        count = n / 2 + 1;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < 3 * n; j++)
            {
                if ((j == midPoint - count) | (j == midPoint + count))
                {
                    Console.Write("*");
                }
                else 
                {
                    Console.Write(".");
                }
            }
            count++;
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', 3 * n));
    }
}

