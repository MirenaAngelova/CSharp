using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _01.A4
{
    class Program
    {
        static void Main(string[] args)
        {
            //#Pesho: @Sofia 16:00
            //#Ani: @Sofia 22:00
            //#Ani: @Sofia 16:00
            //#Mincho: @Plovdiv16:00
            //#TriFon: @Plovdiv 22:00
            //#TriFon: @Plovd1v 23:00
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, List<DateTime>>> events =
                new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d{2}:\d{2})";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    string person = match.Groups[1].Value;
                    string location = match.Groups[2].Value;

                    DateTime time = DateTime.Parse(match.Groups[3].Value);
                    if (time.Hour < 0 && time.Hour > 23 && time.Minute < 0 && time.Minute > 59)
                    {
                        break;
                    }

                    if (!events.ContainsKey(location))
                    {
                        events.Add(location, new SortedDictionary<string, List<DateTime>>());
                    }

                    if (!events[location].ContainsKey(person))
                    {
                        events[location].Add(person, new List<DateTime>());
                    }
                    events[location][person].Add(time);
                }
            }

            string[] locations = Console.ReadLine().Split(',');
            foreach (var location in events)
            {
                if (locations.Contains(location.Key))
                {
                    Console.WriteLine($"{location.Key}:");
                    int i = 1;
                    foreach (var person in location.Value)
                    {
                        
                        if (person.Value.Count > 1)
                        {
                            //Console.WriteLine( $"{i}. {person.Key} -> {person.Value}");
                            Console.WriteLine( String.Format("{0}. {1} -> {2}",
                                i, person.Key, person.Value));
                        }
                        else
                        {
                            //Console.WriteLine($"{i}. {person.Key} -> {string.Join(", ", person.Value)}");
                            Console.WriteLine(
                                string.Format("{0}. {1} -> {2}",
                                i, person.Key, string.Join(", ", person.Value)));
                        }
                        i++;
                        
                    }
                    
                }
            }
        }
    }
}
