using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.Сръбско_Unleashed
{
    public class СръбскоUnleashed
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> srubskoUnleashed =
                new Dictionary<string, Dictionary<string, int>>();
            string pattern =
                @"([A-Za-z]*\s*[A-Za-z]*\s*[A-Za-z]+)\s@([A-Za-z]*\s*[A-Za-z]*\s*[A-Za-z]+)\s(\d+)\s(\d+)";
            string input = Console.ReadLine();

            while (input != "End")
            {
                Regex patternRegex = new Regex(pattern);
                Match match = patternRegex.Match(input);

                if (match.Success)
                {
                    string singer = match.Groups[1].Value;
                    string venue = match.Groups[2].Value;
                    int ticketPrice = int.Parse(match.Groups[3].Value);
                    int ticketCount = int.Parse(match.Groups[4].Value);

                    if (!srubskoUnleashed.ContainsKey(venue))
                    {
                        srubskoUnleashed.Add(venue, new Dictionary<string, int>());
                    }

                    if (!srubskoUnleashed[venue].ContainsKey(singer))
                    {
                        srubskoUnleashed[venue].Add(singer, 0);
                    }

                    srubskoUnleashed[venue][singer] += ticketPrice*ticketCount;
                }

                input = Console.ReadLine();
            }

            foreach (var venue in srubskoUnleashed)
            {
                Console.WriteLine($"{venue.Key}");
                foreach (var singer in srubskoUnleashed[venue.Key].OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
