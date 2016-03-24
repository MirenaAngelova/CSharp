using System;
class Boat
{
    static void Main()
    {
        //We all know Popeye the Sailor Man. In this episode he was captured and thrown in a prison by Bluto 
        //on a lonely island in the middle of the Atlantic Ocean. He used his last spinach can to break out of the prison,
        //but he still had to escape from the island. His only chance to survive and rescue his beloved Olive Oil 
        //is to somehow find a boat, but sadly the Animator doesn't know how to draw boats. Your task is to draw a boat 
        //by given N (the height and width of the sail) and bring this story to a happy ending.
        //Input
        //The input data should be read from the console.
        //On the only input line you have an integer number N, showing the height and width of the sail.
        //The body of the boat should be exactly (N – 1) / 2 lines high.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data should be printed on the console.
        //You must print the boat on the console. Each row contains only characters "." (dot)  or "*" (asterisk).
        //The first row should have exactly one "*" in the middle (that is the top of the sail) and every next line should 
        //have two more.
        //The first row of the body should have exactly N * 2 "*" and every next line, two asterisk less. 
        //(see the example below)
        //Constraints
        //•	The number N will always be an odd integer number in the range [3…39].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output		Input	Output
        //3	        ..*...      5       ....*.....
        //          ***...              ..***.....
        //          ..*...              *****.....
        //          ******		        ..***.....
        //                              ....*.....
        //                              **********
        //                              .********.
        //

        int n = int.Parse(Console.ReadLine());
        int midPoint = (n * 2 - 1) / 2;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 2 * n; j++)
            {
                if ((j >= midPoint - count) & (j <= midPoint))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            if (i < n / 2)
            {
                count += 2;
            }
            else
            {
                count -= 2;
            }
        }
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine(new string('.', i) + new string('*', (2 * n) - (2 * i)) + new string('.', i));
        }
    }
}

