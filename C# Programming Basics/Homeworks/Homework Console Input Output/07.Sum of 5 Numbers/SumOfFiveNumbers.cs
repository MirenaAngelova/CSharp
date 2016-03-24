using System;
class SumOfFiveNumbers
{
    static void Main()
    {
        //Write a program that enters 5 numbers (given in a single line, separated by a space), 
        //calculates and prints their sum. Examples:
        //numbers	  sum		numbers	         sum		numbers	                sum
        //1 2 3 4 5	  15		10 10 10 10 10	 50		    1.5  3.14  8.2  -1  0	11.84

        string[] fiveNumbers = Console.ReadLine().Split(' ');
        double n1 = double.Parse(fiveNumbers[0]);
        double n2 = double.Parse(fiveNumbers[1]);
        double n3 = double.Parse(fiveNumbers[2]);
        double n4 = double.Parse(fiveNumbers[3]);
        double n5 = double.Parse(fiveNumbers[4]);
        Console.WriteLine(n1 + n2 + n3 + n4 + n5);

    }
}

