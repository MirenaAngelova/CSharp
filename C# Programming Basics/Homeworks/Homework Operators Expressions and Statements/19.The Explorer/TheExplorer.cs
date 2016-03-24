using System;
class TheExplorer
{
    static void Main()
    {
        //Bai Vylcho is very an enthusiastic explorer. His passion are the diamonds, he just adores them. 
        //Today he is going on an expedition to collect all kind of diamonds, no matter small or large. 
        //Help your friend to find all the diamonds in the biggest known cave "The Console Cave". 
        //At the only input line you will be given the width of the diamond. The char that forms the outline 
        //of the diamonds is '*' and the surrounding parts are made of '-' (see the examples). Your task is 
        //to print a diamond of given size n.
        //Input
        //Input data should be read from the console. 
        //•	The only input line will hold the width of the diamond – n.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	The output lines should hold the diamond.
        //Constraints
        //•	The number n is positive odd integer between 3 and 59, inclusive.
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	  Output		Input	Output
        //5	      --*--	        7       ---*---
        //        -*-*-                 --*-*--
        //        *---*                 -*---*-
        //        -*-*-                 *-----*
        //		  --*--                 -*---*-
        //                              --*-*--
        //                              ---*---

        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        int midPoint = n / 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((j == midPoint - counter) | (j == midPoint + counter))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }

            if (i >= midPoint)
            {
                counter--;
            }
            else
            {
                counter++;
            }
            Console.WriteLine();
           
        }
       
    }
}

