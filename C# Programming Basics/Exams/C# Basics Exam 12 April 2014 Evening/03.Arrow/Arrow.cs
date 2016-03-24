using System;
class Arrow
{
    static void Main()
    {
        //SoftUni has opened a new training center in Kaspichan, but the people there did not know how to find it. 
        //Your task is to print a vertical arrow, which will be used to indicate the path to the new building in the city. 
        //This will help thousands of people to become software engineers. Please help them!
        //Input
        //The input data should be read from the console.
        //•	On the only line will hold and integer number N (always odd number), indicating the width of the arrow. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. Use the “#” (number sign) to mark the arrow and “.” (dot) for the rest. 
        //Follow the examples below.
        //Constraints
        //•	N will always be a positive odd number between 3 and 79 inclusive.
        //•	Allowed working time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	     Output		  Input	    Output		        Input	Output
        //5	        ..#####..     9	    ....#########....       3	    .###.
        //          ..#...#..           ....#.......#....               .#.#.
        //          ..#...#..           ....#.......#....               ##.##
        //          ..#...#..           ....#.......#....               .#.#.         
        //          ###...###           ....#.......#....               ..#..         
        //          .#.....#.           ....#.......#....         
        //          ..#...#..           ....#.......#....         
        //          ...#.#...           ....#.......#....
        //	        ....#....	        #####.......#####
        //                              .#.............#.
        //                              ..#...........#..
        //                              ...#.........#...
        //                              ....#.......#....
        //                              .....#.....#.....
        //                              ......#...#......
        //                              .......#.#.......
        //                              ........#........
	
        int n = int.Parse(Console.ReadLine());
        string dot = new string('.', n / 2);
        string dots = new string('.', n - 2);
        string hash = new string('#', n);
        int midPoint = ((n * 2) - 1) / 2;
        int dotCount = midPoint - 1;
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}", dot, hash, dot);
            }
            
            else if ((i > 0) & (i < n - 1))
            {
                Console.WriteLine(dot + '#' + dots + '#' + dot);
               
            }
            else
            {
                string hashN = new string('#', (n / 2) + 1);
                Console.WriteLine("{0}{1}{0}", hashN, dots, hashN);
            }
        }
        for (int i = 0; i < (n - 1); i++)
        {
            for (int j = 0; j < (n * 2) - 1; j++)
            {
                if ((j == midPoint - dotCount) | (j == midPoint + dotCount))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            dotCount--;
            Console.WriteLine();
            
        }



        //int n = int.Parse(Console.ReadLine());
        //Console.WriteLine(new string('.', n / 2) + new string('#', n) + new string('.', n / 2));
        //for (int i = 0; i < n - 2; i++)
        //{
        //    Console.WriteLine(new string('.', n / 2) + "#" + new string('.', n - 2) + "#" + new string('.', n / 2));
        //}
        //Console.WriteLine(new string('#', n / 2 + 1) + new string('.', n - 2) + new string('#', n / 2 + 1));
        //for (int i = 0; i < n - 2; i++)
        //{
        //    Console.WriteLine(new string('.', i + 1) + "#" + new string('.', 2 * n - 5 - 2 * i) + "#" + new string('.', i + 1));
        //}
        //Console.WriteLine(new string('.', (2 * n - 1) / 2) + "#" + new string('.', (2 * n - 1) / 2));
    }
}

