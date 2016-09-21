using System;
using System.Collections.Generic;
using System.Linq;
class OfficeStuff
{
    static void Main()
    {
        SortedDictionary<string, Dictionary<string, int>> companiesAlfabetical = 
            new SortedDictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] companies = Console.ReadLine()
                .Split(new char[] { '|', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            FillDictionary(companies, companiesAlfabetical);
        }
        Print(companiesAlfabetical);
    }
    private static void FillDictionary(string[] companies,
        SortedDictionary<string, Dictionary<string, int>> companiesAlfabetical)
    {
        string company = companies[0];
        int amount = int.Parse(companies[1]);
        string product = companies[2];

        if (!companiesAlfabetical.ContainsKey(company))
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add(product, 0);

            companiesAlfabetical.Add(company, products);
        }
        else if (!companiesAlfabetical[company].ContainsKey(product))
        {
            companiesAlfabetical[company].Add(product, 0);
        }

        companiesAlfabetical[company][product] += amount;
    }
    private static void Print(SortedDictionary<string, Dictionary<string, int>> companiesAlphabetical)
    {
        List<string> result = new List<string>();

        foreach (var pair1 in companiesAlphabetical)
        {
            Console.Write("{0}: ", pair1.Key);

            result.AddRange(pair1.Value.Select(pair2 => String.Format("{0}-{1}", pair2.Key, pair2.Value)));

            Console.WriteLine(string.Join(", ", result));

            result.Clear();
        }
    }
}