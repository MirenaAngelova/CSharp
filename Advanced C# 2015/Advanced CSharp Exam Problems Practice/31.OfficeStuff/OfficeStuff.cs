using System;
using System.Collections.Generic;
using System.Linq;

class OfficeStuff
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());

        //SortedDictionary<string, Dictionary<string, int>> companies =
        //        new SortedDictionary<string, Dictionary<string, int>>();

        //for (int i = 0; i < n; i++)
        //{
        //    string input = Console.ReadLine();
        //    string[] company = input.Split(new char[] {' ', '-', '|'}, StringSplitOptions.RemoveEmptyEntries);

        //    string name = company[0];
        //    string stuff = company[2];
        //    int amount = int.Parse(company[1]);

        //    if (!companies.ContainsKey(name))
        //    {
        //        Dictionary<string, int> stuffs = new Dictionary<string, int>() { { stuff, 0 } };

        //        companies.Add(name, stuffs);
        //    }
        //    else if (!companies[name].ContainsKey(stuff))
        //    {
        //        companies[name].Add(stuff, 0);
        //    }

        //    companies[name][stuff] += amount;
        //}

        //List<string> output = new List<string>();

        //foreach (var pair1 in companies)
        //{
        //    Console.Write("{0}: ", pair1.Key);

        //    output.AddRange(pair1.Value.Select(pair2 => string.Format("{0}-{1}", pair2.Key, pair2.Value)));

        //    Console.WriteLine(string.Join(", ", output));

        //    output.Clear();
        //}

        //|SoftUni - 600 - paper|
        SortedDictionary<string, Dictionary<string, int>> companies =
            new SortedDictionary<string, Dictionary<string, int>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string company = input[0];
            int amount = int.Parse(input[1]);
            string product = input[2];

            if (!companies.ContainsKey(company))
            {
                companies.Add(company, new Dictionary<string, int>());
            }

            if (!companies[company].ContainsKey(product))
            {
                companies[company].Add(product, 0);
            }

            companies[company][product] += amount;
        }
        foreach (var company in companies)
        {
            Console.Write($"{company.Key}: ");
            int count = 0;
            foreach (var product in company.Value)
            {
                count++;
                Console.Write($"{product.Key}-{product.Value}");
                if (company.Value.Count != count)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }


    }
}

