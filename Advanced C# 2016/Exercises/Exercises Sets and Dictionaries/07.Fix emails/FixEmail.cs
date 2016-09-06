using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.Fix_emails
{
    public class FixEmail
    {
        public static void Main()
        {
            Dictionary<string, string> names = new Dictionary<string, string>();
            string pattern = @"(.*?).(us|uk)";
            Regex patternRegex = new Regex(pattern);
            string name = Console.ReadLine();
            while (name != "stop")
            {
                string email = Console.ReadLine();
                Match match = patternRegex.Match(email);
                if (!match.Success && !names.ContainsKey(name))
                {
                    names.Add(name, email);
                    
                }

                name = Console.ReadLine();
            }

            foreach (var item in names)
            {
                Console.WriteLine($"{item.Key} – > {item.Value}");
            }
        }
    }
}
