using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string pattern = @"(.*?)-(\+*\d+\/*\d+)";
            Regex patternRegex = new Regex(pattern);

            string input = Console.ReadLine();
            while (input != "search")
            {
                Match match = patternRegex.Match(input);
                string name = match.Groups[1].Value;
                string phone = match.Groups[2].Value;

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, phone);
                }

                phonebook[name] = phone;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
