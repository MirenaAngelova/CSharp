using System;
class HalfSum
{
    static void Main()
    {
        //Nakov likes numbers. He often plays with their sums and differences. Once he invented the following game. 
        //He takes a sequence of numbers, splits them into two subsequences with the same number of elements 
        //and sums the left and right sub-sums, and compares the sub-sums. Please help him.
        //You are given a number n and 2*n numbers. Write a program to check whether the sum of the first n numbers 
        //is equal to the sum of the second n numbers. Print as result “Yes” or “No”. In case of yes, print also the sum. 
        //In case of no, print also the difference between the left and the right sums.
        //Input
        //The input data should be read from the console.
        //•	The first line holds an integer n – the count of numbers.
        //•	Each of the next 2*n lines holds exactly one number.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output must be printed on the console.
        //•	Print “Yes, sum=S” where S is the sum of the first n numbers in case of the sum of the first n numbers 
        //is equal to the sum of the second n numbers.
        //•	Otherwise print “No, diff=D” where D is the difference between the sum of the first n numbers 
        //and the sum of the second n numbers. D should always be a positive number.
        //Constraints
        //•	The number n is integer in range [0...500].
        //•	All other numbers are integers in range [-500 000 ... 500 000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	  Output		    Input	Output		    Input	Output
        //4       Yes, sum=5		3       No, diff=1		2       No, diff=2
        //3                         1                       1
        //4                         2                       1
        //-1                        3                       0
        //-1                        1                       0	
        //2                         2
        //1                         2
        //1
        //1	

        int n = int.Parse(Console.ReadLine());
        int sumFirst = 0;
        int sumSecond = 0;
        int diff = 0;
        for (int i = 0; i < n * 2; i++)
        {
            if (i < n)
            {
                int numberFirst = int.Parse(Console.ReadLine());
                sumFirst += numberFirst;
            }
            else
            {
                int numberSecond = int.Parse(Console.ReadLine());
                sumSecond += numberSecond;
            }
        }
        if (sumFirst == sumSecond)
        {
            Console.WriteLine("Yes, sum={0}", sumFirst);
        }
        else
        {
            diff = Math.Abs(sumFirst - sumSecond);
            Console.WriteLine("No, diff={0}", diff);
        }
    }
}

