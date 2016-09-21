using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _47.Largest_3_Rectangles
{
    class Largest3Rectangles
    {
        static void Main(string[] args)
        {
            //  [12x7][3x5][10x12]  [4x3][1x8]  
            List<int> areas = new List<int>();
            string input = Console.ReadLine().Trim().Replace("\\s+\\t", String.Empty);
            int[] inputLine = new Regex("[\\[\\]x\\s]+")
                .Replace(input, " ")
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();

            
            for (int i = 0; i < inputLine.Length; i += 2)
            {
                int area = inputLine[i] * inputLine[i + 1];
                areas.Add(area);
            }

            long sum = 0;
            long maxSum = long.MinValue;
            int index = 0;
            for (int i = 0; i < areas.Count - 2; i++)
            {
                sum = areas[i] + areas[i + 1] + areas[i + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    //index = i * 2;
                }
            }

            //Console.WriteLine(
            //    $"{inputLine[index]}*{inputLine[index + 1]} + " +
            //    $"{inputLine[index + 2]}*{inputLine[index + 3]} + " +
            //    $"{inputLine[index + 4]}*{inputLine[index + 5]} = {maxSum}");

            Console.WriteLine(maxSum);
        }
    }
}
