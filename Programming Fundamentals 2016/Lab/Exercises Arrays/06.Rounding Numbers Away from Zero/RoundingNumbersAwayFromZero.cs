using System;
using System.Linq;

namespace _06.Rounding_Numbers_Away_from_Zero
{
    public class RoundingNumbersAwayFromZero
    {
        public static void Main()
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var number in array)
            {
                //Console.WriteLine(
                //    $"{number} => {Math.Round(number, MidpointRounding.AwayFromZero)}");
                double num = Math.Abs(number) + 0.5;
                Console.WriteLine(number < 0 ? $"-{(int)num}" : $"{(int)num}");
            }
        }
    }
}
