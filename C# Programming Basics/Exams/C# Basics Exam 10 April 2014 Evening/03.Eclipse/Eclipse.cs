using System;
class Eclipse
{
    static void Main()
    {
        //Write a program to print a figure at the console in the form of sunglasses for watching the solar eclipse.
        //Input
        //•	The input data should be read from the console.
        //•	You have an integer number N (always an odd number) specifying the height of sunglasses.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console.
        //You should print the sunglasses on the console. The sunglasses consist of three parts: 
        //frames, lenses and a bridge (the connection between the two frames). 
        //Each frame's width is double the height N and should be printed using the character '*' (asterisk) 
        //without the corners which should be printed with ' ' (space). Print the lenses with the character '/'. 
        //Finally, connect the two frames with a bridge that is of size N-1, using the character '-'. 
        //Leave the rest of the space between the frames blank.
        //Constraints
        //•	The number N will be a positive odd integer number in range [3…101].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	        Output		        Input	Output
        //3	            ****    ****        7        ************        ************
        //             *////*--*////*               *////////////*      *////////////*
        //              ****    ****	            *////////////*      *////////////*	
        //                                          *////////////*------*////////////*
        //                                          *////////////*      *////////////*
        //                                          *////////////*      *////////////*
        //                                           ************        ************ 

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if ((i == 0) | (i == n - 1))
            {
                PrintTopBottomEclipse(n);
            }
            else
            {
                PrintMiddleEclipse(n, i);
            }
        }
    }
    private static void PrintMiddleEclipse(int n, int i)
    {
        string eyes = new string('/', (n * 2) - 2);
        string nothing = new string(' ', n - 1);
        string middleFrame = string.Format("{0}{1}{0}", '*', eyes);
        if (i == n / 2)
        {
            nothing = new string('-', n - 1);
        }
        Console.WriteLine("{0}{1}{0}", middleFrame, nothing);
    }
    private static void PrintTopBottomEclipse(int n)
    {
        string topBottomFrame = new string('*', (n * 2) - 2);
        string topBottomNothing = new string(' ', n + 1);
        Console.WriteLine(" {0}{1}{0} ", topBottomFrame, topBottomNothing);
    }
}


