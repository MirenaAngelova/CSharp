using System;
using System.Collections.Generic;
using System.Linq;

class PythagoreanNumbers
{
    static void Main()
    {
        //George likes math. Recently he discovered an interesting property of the Pythagorean Theorem: 
        //there are infinite number of triplets of integers a, b and c (a ≤ b), such that a2 + b2 = c2. 
        //Write a program to help George find all such triplets (called Pythagorean numbers) among a set of integer numbers.
        //Input
        //The input data should be read from the console. At the first line, we have a number n – 
        //the count of the input numbers. At the next n lines we have n different integers.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print at the console all Pythagorean equations a2 + b2 = c2 (a ≤ b), which can be formed by the input numbers. 
        //Each equation should be printed in the following format: "a*a + b*b = c*c". The order of the equations is 
        //not important. Beware of spaces: put spaces around the "+" and "=". In case of no Pythagorean numbers found, 
        //print "No".
        //Constraints
        //•	All input numbers will be unique integers in the range [0 … 999].
        //•	The count of the input numbers will be in the range [1 ... 100].
        //•	Time limit: 0.3 sec. Memory limit: 16 MB.
        //Examples
        //Input	   Output		      Input	    Output		            Input	Output
        //8     5*5 + 12*12 = 13*13   5         3*3 + 4*4 = 5*5         3       No
        //41    9*9 + 40*40 = 41*41   3         0*0 + 3*3 = 3*3         10
        //5     3*3 + 4*4 = 5*5		  12        0*0 + 12*12 = 12*12     20
        //9                           5         0*0 + 5*5 = 5*5         30
        //12                          0         0*0 + 0*0 = 0*0
        //4                           4	        0*0 + 4*4 = 4*4		
        //13                            
        //40
        //3	

        int n = int.Parse(Console.ReadLine());
        List<int> uniqueInt = new List<int>();

        //int counter = 0;
        //while (counter < n )
        //{
        //    uniqueInt.Add(int.Parse(Console.ReadLine()));
        //    counter++;
        //}

        for (int i = 0; i < n; i++)
        {
            uniqueInt.Add(int.Parse(Console.ReadLine()));
        }
        uniqueInt.Sort();
        bool notFound = false;

        //foreach (int a in uniqueInt)
        //{
        //    foreach (int b in uniqueInt.Where(b => b >= a))
        //    {
        //        foreach (int c in uniqueInt.Where(c => c * c == a * a + b * b))
        //        {
        //            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
        //            notFound = true;
        //        }
        //    }
        //}

        for (int a = 0; a < uniqueInt.Count; a++)
        {
            for (int b = a; b < uniqueInt.Count; b++)
            {
                for (int c = b; c < uniqueInt.Count; c++)
                {
                    if (uniqueInt[a] * uniqueInt[a] + uniqueInt[b] * uniqueInt[b] == uniqueInt[c] * uniqueInt[c])
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", uniqueInt[a], uniqueInt[b], uniqueInt[c]);
                        notFound = true;
                    }
                }
            }
        }
        if (!notFound)
        {
            Console.WriteLine("No");
        }
    }
}
