using System;
using System.Collections.Generic;
using System.Linq;
class CouplesFrequency
{
    static void Main()
    {
        //3 4 2 3 4 2 1 12 2 3 4
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> couples = new Dictionary<string, int>();

        for (int i = 0; i < input.Length - 1; i++)
        {
            string couple = string.Join(" ", input.Skip(i).Take(2));// Skip(0) means nothing

            if (!couples.ContainsKey(couple))
            {
                couples.Add(couple, 0);
            }

            couples[couple]++;
        }

        int allCouples = input.Length - 1;

        //foreach (KeyValuePair<string, int> item in couples)
        //{
        //    Console.WriteLine("{0} -> {1}", item.Key, ((double)item.Value / allCouples).ToString("0.00%"));
        //}

        //3 4-> 30.00 %
        //4 2-> 20.00 %
        //2 3-> 20.00 %
        //2 1-> 10.00 %
        //1 12-> 10.00 %
        //12 2-> 10.00 %

        foreach (var couple in couples)
        {
            double percentage = ((double)couple.Value / allCouples) * 100;
            Console.WriteLine($"{couple.Key}-> {percentage:F2} %");
        }
    }
}

