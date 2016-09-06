using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Square_Numbers
{
    public class SquareNumbers
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<double> squareNums = new List<double>();
            foreach (var num in list)
            {
                double square = Math.Sqrt(num);
                //if (square == (int)square)
                //{
                //    squareNums.Add(num);
                //}
                double squareModulus = square%1.0;
                if (squareModulus == 0)
                {
                    squareNums.Add(num);
                }
            }

            //squareNums.Sort((a, b) => b.CompareTo(a));
            squareNums.Sort((a, b) => -a.CompareTo(b));

            Console.WriteLine(string.Join(" ", squareNums));
        }
    }
}
