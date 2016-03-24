using System;
using System.Linq;
class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        //Write a program that reads from the console a sequence of n integer numbers and returns the minimal, 
        //the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). 
        //The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. 
        //The output is like in the examples below. Examples:
        //input	output		 input	output
        //3     min = 1      2      min = -1
        //2     max = 5      -1     max = 4 	
        //5     sum = 8      4      sum = 3
        //1     avg = 2.67          avg = 1.50	           
        //                                 

        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int minNum = numbers.Min();
        int maxNum = numbers.Max();
        int sumOfNum = numbers.Sum();
        double averageOfNum = numbers.Average();
        Console.WriteLine("min = {0} \nmax = {1} \nsum = {2} \navg = {3:f2}",minNum, maxNum, sumOfNum, averageOfNum);
    }
}

