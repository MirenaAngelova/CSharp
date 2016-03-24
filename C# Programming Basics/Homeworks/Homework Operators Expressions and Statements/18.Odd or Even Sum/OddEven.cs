using System;
class OddEven
{
    static void Main()
    {
        //You are given a number n and 2*n numbers. Write a program to check whether the sum of the odd numbers 
        //is equal to the sum of the even n numbers. The first number is considered odd, the next even, 
        //the next odd again, etc. Print as result “Yes” or “No”. In case of yes, print also the sum. 
        //In case of no, print also the difference between the odd and the even sums.
        //Input
        //The input data should be read from the console.
        //•	The first line holds an integer n – the count of numbers.
        //•	Each of the next 2*n lines holds exactly one number.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output must be printed on the console.
        //•	Print “Yes, sum=S” where S is the sum of the odd n numbers in case of the sum of the odd n numbers 
        //is equal to the sum of the even n numbers.
        //•	Otherwise print “No, diff=D” where D is the difference between the sum of the odd n numbers 
        //and the sum of the even n numbers. D should always be a positive number.
        //Constraints
        //•	The number n is integer in range [0...500].
        //•	All other numbers are integers in range [-500 000 ... 500 000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	 Output		  Input	  Output		Input	Output
        //4      Yes, sum=5   3	      No, diff=1	2       No, diff=2
        //3                   1                     1	
        //4                   2                     0
        //-1                  3                     1
        //-1                  1                     0	
        //2                   2                    
        //1                   2
        //1
        //1

        int n = int.Parse(Console.ReadLine());
        int sum1 = 0;
        int sum2 = 0;
        
        for (int i = 1; i <= (2 * n); i ++)
        {
            if (i % 2 == 0)
            {
                int number = int.Parse(Console.ReadLine());
                sum1 += number;
            }
            else
            {
                int number = int.Parse(Console.ReadLine());
                sum2 += number;
            }
           
        }
        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum={0}", sum1);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum1 - sum2));
        }
    }
}

