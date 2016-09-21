using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class OlympicsAreComming
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> countries =
                new Dictionary<string, Dictionary<string, int>>();
        string inputLine = Console.ReadLine().Trim();
        while (inputLine != "report")
        {
            string[] input = inputLine.Split('|');
            string athlete = Regex.Replace(input[0].Trim(), "\\s+", " ");
            string country = Regex.Replace(input[1].Trim(), "\\s+", " ");

            if (!countries.ContainsKey(country))
            {
                countries.Add(country, new Dictionary<string, int>());
            }

            if (!countries[country].ContainsKey(athlete))
            {
                countries[country].Add(athlete, 0);
            }

            countries[country][athlete]++;
            inputLine = Console.ReadLine().Trim();
        }

        var sortedCountries = countries.OrderByDescending(c => c.Value.Sum(a => a.Value));
        foreach (var country in sortedCountries)
        {//Bulgaria (2 participants): 3 wins
            Console.Write($"{country.Key} ({country.Value.Count} participants): ");

            Console.WriteLine($"{country.Value.Sum(a => a.Value)} wins");
        }
    }
}