using System;
using System.Linq;
class NumberCalculation
{
    static void Main()
    {
        //Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers. 
        //Overload the methods to work with numbers of type double and decimal.
        //Note: Do not use LINQ.
        //double        124.12 0.12 111.4444444 1.23456789
        //decimal       11.22222222222222222222222222 565656565.5656565656565 

        double[] doubleNum = Console.ReadLine().Split().Select(double.Parse).ToArray();
        decimal[] decimalNum = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

        Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}, Average: {3}, Product: {4}",
            GetMin(doubleNum), GetMax(doubleNum), GetSum(doubleNum), GetAverage(doubleNum), GetProduct(doubleNum));

        Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}, Average: {3}, Product: {4}",
            GetMin(decimalNum), GetMax(decimalNum), GetSum(decimalNum), GetAverage(decimalNum), GetProduct(decimalNum));

    }
    private static double GetMin(double[] num)
    {
        double min = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] < min)
            {
                min = num[i];
            }
        }
        return min;
    }
    private static decimal GetMin(decimal[] num)
    {
        decimal min = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] < min)
            {
                min = num[i];
            }
        }
        return min;
    }
    private static double GetMax(double[] num)
    {
        double max = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] > max)
            {
                max = num[i];
            }
        }
        return max;
    }
    private static decimal GetMax(decimal[] num)
    {
        decimal max = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            if (num[i] > max)
            {
                max = num[i];
            }
        }
        return max;
    }
    private static double GetSum(double[] num)
    {
        double sum = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            sum += num[i];
        }
        return sum;
    }
    private static decimal GetSum(decimal[] num)
    {
        decimal sum = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            sum += num[i];
        }
        return sum;
    }
    private static double GetAverage(double[] num)
    {
        return GetSum(num) / num.Length;
    }
    private static decimal GetAverage(decimal[] num)
    {
        return GetSum(num) / num.Length;
    }
    private static double GetProduct(double[] num)
    {
        double product = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            product *= num[i];
        }
        return product;
    }
    private static decimal GetProduct(decimal[] num)
    {
        decimal product = num[0];

        for (int i = 1; i < num.Length; i++)
        {
            product *= num[i];
        }
        return product;
    }
}