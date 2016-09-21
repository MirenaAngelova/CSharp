using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class TextTransformer
{
    static void Main()
    {
        const string Pattern = @"([$%&'])([^$%&']+)\1";

        Dictionary<char, int> symbols = new Dictionary<char, int> 
        {
            {'$', 1}, 
            {'%', 2}, 
            {'&', 3}, 
            {'\'', 4}
        };

        StringBuilder sb = new StringBuilder();

        string command = Console.ReadLine();

        while (command != "burp")
        {
            sb.Append(command);
            command = Console.ReadLine();
        }

        string text = Regex.Replace(sb.ToString(), @"\s+", " ");
        Regex rgx = new Regex(Pattern);
        MatchCollection matches = rgx.Matches(text);

        StringBuilder result = new StringBuilder();

        foreach (Match match in matches)
        {
            char symbol = match.Groups[1].Value[0];
            string captures = match.Groups[2].Value;
            int length = captures.Length;


            for (int i = 0; i < length; i++)
            {
                char operations;

                if (i % 2 == 0)
                {
                    operations = (char)(captures[i] + symbols[symbol]);
                }
                else
                {
                    operations = (char)(captures[i] - symbols[symbol]);
                }

                result.Append(operations);
            }

            result.Append(" ");
        }

        Console.WriteLine(result);
    }
}