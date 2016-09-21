using System;
using System.Collections.Generic;
using System.Linq;

class PythagoreanNumbers
    {
        static void Main()
        {
        //int n = int.Parse(Console.ReadLine());
        //int[] numbers = new int[n];
        //bool noFound = false;

        //for (int i = 0; i < n; i++)
        //{
        //    numbers[i] = int.Parse(Console.ReadLine());
        //}

        //foreach (int a in numbers)
        //{
        //    foreach (int b in numbers)
        //    {
        //        foreach (int c in numbers)
        //        {
        //            if (a <= b && a * a + b * b == c * c)
        //            {
        //                Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);

        //                noFound = true;
        //            }
        //        }
        //    }
        //}

        //if (!noFound)
        //{
        //    Console.WriteLine("No");
        //}

        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        numbers.Sort();
        bool isFound = false;
        foreach (var a in numbers)
        {
            foreach (var b in numbers.Where(b => b >= a))
            {
                foreach (var c in numbers.Where(c => c * c == a * a + b * b))
                {
                    Console.WriteLine($"{a}*{a} + {b}*{b} = {c}*{c}");
                    isFound = true;
                }
            }
        }

        if (!isFound)
        {
            Console.WriteLine("No");
        }
    }
    }

