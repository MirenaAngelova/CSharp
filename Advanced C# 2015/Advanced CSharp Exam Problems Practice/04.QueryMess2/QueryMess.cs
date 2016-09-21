using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class QueryMess
{
    static void Main()
    {
        Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            input = Regex.Replace(input, @"(\+|%20)", " ");
            input = Regex.Replace(input, @"\s+", " ");

            string pattern = @"([^=&?]+)=([^&]+)";

            Match matches = Regex.Match(input, pattern);

            while (matches.Success)
            {
                string key = matches.Groups[1].Value.Trim();
                string value = matches.Groups[2].Value.Trim();

                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, new List<string>());
                }

                pairs[key].Add(value);

                matches = matches.NextMatch();
            }

            foreach (var pair in pairs)
            {
                Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
            }

            pairs.Clear();
            Console.WriteLine();
        }

    }
}