using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _27.Simple_Expression
{
    class SimpleExpression
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine().Trim().Replace("\\s+", " ");
            decimal[] digits = new Regex("[^\\d\\.]+")
                .Replace(inputLine, " ")
                .Split()
                .Select(decimal.Parse)
                .ToArray();

            string[] operatorSigh = new Regex("[\\d\\.\\s]+")
                .Replace(inputLine, " ")
                .Trim()
                .Split()
                .ToArray();
            decimal sum = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                if (operatorSigh[i - 1] == "+")
                {
                    sum += digits[i];
                }
                else
                {
                    sum -= digits[i];
                }
            }

            Console.WriteLine($"{sum:F7}");
        }
    }
}
