using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Pyramid
{
    static void Main()
    {
        //List<int> sequence = new List<int>();

        //int n = int.Parse(Console.ReadLine());

        //int previousNum = int.Parse(Console.ReadLine().Trim());
        //sequence.Add(previousNum);

        //for (int i = 1; i < n; i++)
        //{
        //    int[] pyramidRows = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(x => int.Parse(x)).ToArray();

        //    bool isFound = false;

        //    int minNum = int.MaxValue;

        //    for (int j = 0; j < pyramidRows.Length; j++)
        //    {

        //        if (pyramidRows[j] < minNum && pyramidRows[j] > previousNum)
        //        {
        //            minNum = pyramidRows[j];

        //            isFound = true;
        //        }
        //    }

        //    if (isFound)
        //    {
        //        sequence.Add(minNum);
        //        previousNum = minNum;
        //    }
        //    else
        //    {
        //        previousNum++;
        //    }
        //}

        //Console.WriteLine(string.Join(", ", sequence));

        //3
        //    2
        //  5  8
        //4 9 10
        List<int> sequence = new List<int>();
        int n = int.Parse(Console.ReadLine());
        int previous = int.Parse(Console.ReadLine());
        sequence.Add(previous);
        for (int i = 0; i < n - 1; i++)
        {
            int[] input = new Regex("[\\s\\t]+")
                .Replace(Console.ReadLine(), " ")
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Array.Sort(input);
            bool isFound = false;
            foreach (var num in input)
            {
                if (num > previous)
                {
                    previous = num;
                    sequence.Add(previous);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                previous++;
            }
            //2, 5, 9
        }

        Console.WriteLine(string.Join(", ", sequence));
    }
}

