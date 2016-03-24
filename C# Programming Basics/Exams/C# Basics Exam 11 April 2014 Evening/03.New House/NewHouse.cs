using System;
class NewHouse
{
    static void Main()
    {
        //Little Joro likes to build huts. After he built all the huts in his whole village, he decided to go to the big city 
        //and start building houses. But his knowledge of how to do this is limited. Help Joro to design the façade of 
        //a beautiful house by printing it to the console. The house must have a roof and one floor. The roof must contains 
        //only the symbols ‘*’ and ‘-’ and the floor must contains the symbols ‘*’ and ‘|’ (see the examples below).
        //Input
        //•	The input data should be read from the console.
        //•	At the only input line you are given an integer number N (always an odd number) showing the height of the house 
        //(without the roof).
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output should be printed on the console.
        //•	You should print the house on the console, just like in the examples below. Each row can contain only 
        //the following characters: “-” (dash), “*” (asterisk) and “|” (pipe). 
        //Constraints
        //•	The number N will be a positive odd integer number between 3 and 101, inclusive.
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output		Input	Output		Input	Output
        //3         -*-         5	    --*--       7	    ---*---
        //          ***                 -***-               --***--
        //          |*|                 *****               -*****-
        //          |*|                 |***|               *******
        //		    |*|                 |***|               |*****|
        //                              |***|               |*****|
        //                              |***|               |*****|
        //                              |***|               |*****|	
        //                                                  |*****|
        //                                                  |*****|
        //                                                  |*****|
        //	

        int n = int.Parse(Console.ReadLine());
        int midPoint = n / 2;
        int count = 0;

        for (int i = 0; i < (midPoint + 1); i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((j >= (midPoint - count)) & (j <= (midPoint + count)))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }
            count++;
            Console.WriteLine();
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("|" + new string('*', n - 2) + "|");
        }
    }
}

