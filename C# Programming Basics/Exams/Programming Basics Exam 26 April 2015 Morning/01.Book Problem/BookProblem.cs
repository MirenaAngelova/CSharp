using System;

namespace _01.Book_Problem
{
    class BookProblem
    {
        static void Main()
        {
            //Stefan is a keen reader. He wants to read a programming book and wants to know exactly when he will finish it.
            //Every day in a given month he reads up some pages. Some days he goes camping and on these days he doesn’t read.
            //You will be given the book’s page count, the number of camping days in a month and number of pages which Stefan reads
            //in a normal day, each on a separate line. Assume each month has 30 days and each year has 12 months. 
            //Calculate how many years and months Stefan will need in order to read the book and print the result on the console 
            //in format “X years Y months”. If Stefan never reads the book, print “never”.
            //Note that if, for example, Stefan needs 3.1 months, you need to round that up – 
            //so you have to print “0 years 4 months”. 
            //Input
            //The input will be read from the console. It consists of exactly three lines:
            //•	On the first line you will be given an integer – the number of pages of the book.
            //•	On the second line you will be given the number of camping days in a month.
            //•	On the third line you will be given the number of pages which Stefan reads every normal day.  
            //The input will always be valid and in the format described, there is no need to check it explicitly.
            //Output
            //The output should be printed on the console.
            //•	On the only output line print the number of years and months Stefan will need to read the book in format
            //“X years Y months”.
            //•	If Stefan cannot read the book, you should print “never”.
            //Constraints
            //•	The number of pages of the book will be an integer in the range [1 … 2 000 000 000].
            //•	The number of camping days will be an integer in the range [0 … 30].
            //•	The number of pages Stefan reads in a normal day will be an integer in the range [0 … 100].
            //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
            //Examples
            //Input	    Output	            Comments
            //250000    83 years 4 months   There are 30 days in a month => 5 camping days and 25 normal days.
            //5                             On a normal day he reads 10 => 25*10 = 250 pages.
            //10		                    On a camping day he doesn’t read.
            //                              250000/250 = 1000 – he needs exactly 1000 months. This is 83 years and 4 months.
            //Input	Output
            //25    never
            //30
            //100	
            //Input	Output
            //24    0 years 1 months
            //0
            //1	

            int p = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double month = Math.Ceiling(p / ((30.0 - c) * n));
            int year = (int)month / 12;
            int months = (int)month % 12;
            if (c >= 30)
            {
                Console.WriteLine("never");
            }
            else
            {
                Console.WriteLine("{0} years {1} months", year, months);
            }
        }
    }
}
