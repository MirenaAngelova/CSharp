using System;
using System.Linq;
using System.Collections.Generic;
class CategorizeNumFindMinMaxAverage
{
    static void Main()
    {
        //Write a program that reads N floating-point numbers from the console. Your task is to separate them in two sets, 
        //one containing only the round numbers (e.g. 1, 1.00, etc.) and the other containing the floating-point numbers
        //with non-zero fraction. Print both arrays along with their minimum, maximum, sum and average 
        //(rounded to two decimal places). Examples:
        //Input	                            Output
        //1.2 -4 5.00 12211 93.003 4 2.2	[1.2, 93.003, 2.2] -> min: 1.2, max: 93.003, sum: 96.403, avg: 32.13
        //                                  [-4, 5, 12211, 4] - > min: -4, max: 12211, sum: 12216, avg: 3054.00

        double[] numbers = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);

        List<double> floatingPoint = new List<double>();
        List<int> round = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 1 != 0)
            {
                floatingPoint.Add(numbers[i]);
            }
            else
            {
                round.Add((int)numbers[i]);
            }
        }
          
            Console.Write("[{0}]", String.Join(", ", floatingPoint));
            Console.Write(" -> min: {0}, max: {1}, sum: {2}, avg: {3:f2}", floatingPoint.Min(), floatingPoint.Max(), 
                floatingPoint.Sum(), floatingPoint.Average());
            Console.WriteLine();
            Console.Write("[{0}]", String.Join(", ", round));
            Console.Write(" - > min: {0}, max: {1}, sum: {2}, avg: {3:f2}", round.Min(), round.Max(), 
                round.Sum(), round.Average());
            Console.WriteLine();

    }
}