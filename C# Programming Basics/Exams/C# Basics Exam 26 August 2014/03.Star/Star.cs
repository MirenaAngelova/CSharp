using System;
class Star
{
    static void Main()
    {
        //You will be given an integer N. Your task is to draw a star on the console. 
        //The width of the star is (2*N+1). The height of the star is (N*2 - (N/2-1)). 
        //The top and the middle part height is exactly (N/2). The height of the legs is (N/2+1). 
        //Check the examples below to understand your task better.
        //Input
        //The input data is read from the console. The number N stays alone at the first line. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	You must print at the console a star of size N following the formulas above and the examples below.
        //Constraints
        //•	N will be a number between 6 and 36 and will be an even number.
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output		    Input	Output		        Input	Output
        //6	    ......*......   8	    ........*........   10	    ..........*..........
        //      .....*.*.....           .......*.*.......           .........*.*.........
        //      ....*...*....           ......*...*......           ........*...*........
        //      ****.....****           .....*.....*.....           .......*.....*.......
        //      .*.........*.           *****.......*****           ......*.......*......
        //      ..*.......*..           .*.............*.           ******.........******
        //      ...*..*..*...           ..*...........*..           .*.................*.
        //      ..*..*.*..*..           ...*.........*...           ..*...............*..
        //      .*..*...*..*.           ....*...*...*....           ...*.............*...
        //      ****.....****           ...*...*.*...*...           ....*...........*....
        //                              ..*...*...*...*..           .....*....*....*.....
        //                              .*...*.....*...*.           ....*....*.*....*....
        //                              *****.......*****           ...*....*...*....*...
        //                                                          ..*....*.....*....*..
        //                                                          .*....*.......*....*.
        //                                                          ******.........******

        int n = int.Parse(Console.ReadLine());
        int midPoint = (2 * n + 1) / 2;
        int count = 0;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < 2 * n + 1; j++)
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
            Console.WriteLine();
            count++;
        }
        Console.WriteLine(new string('*', n / 2 + 1) + new string('.', n - 1) + new string('*', n / 2 + 1));
        count = n - 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            for (int j = 0; j < 2 * n + 1; j++)
            {
                
                if ((j == midPoint - count) | (j == midPoint + count))
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
            count--;
        }
        count = n / 2;
        int counter = 0;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < 2 * n + 1; j++)
            {
                if ((j == midPoint - count) | (j == midPoint + count) | (j == midPoint - counter) | (j == midPoint + counter))
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
            counter++;
        }
        Console.WriteLine(new string('*', n / 2 + 1) + new string('.', n - 1) + new string('*', n / 2 + 1));
    }
}

