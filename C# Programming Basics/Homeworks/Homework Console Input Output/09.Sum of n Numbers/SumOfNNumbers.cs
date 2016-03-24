using System;
class SumOfNNumbers
{
    static void Main()
    {
        //Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. 
        //Note that you may need to use a for-loop. Examples:
        //numbers	sum		numbers	sum		numbers	sum
        //3         90      5       6.5		1  	    1
        //20                2               1
        //60                -1
        //10                -0.5			
        //                  4
        //                  2

        string nStr = Console.ReadLine();
        int n;
        bool isInt = int.TryParse(nStr, out n);
        Console.WriteLine(isInt ? null : "Invalid number!");
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            string str = Console.ReadLine();
            float number;
            if (float.TryParse(str, out number))
            {
                sum += number;
            }
            else
            {
                Console.WriteLine("Invalid number.");
                return;
            }
        }
        Console.WriteLine(sum);
    }
}

