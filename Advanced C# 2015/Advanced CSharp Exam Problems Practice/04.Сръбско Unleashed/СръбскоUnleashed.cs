using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Сръбско_Unleashed
{
    class СръбскоUnleashed
    {
        static void Main()
        {
            //Lepa Brena @Sunny Beach 25 3500
            Dictionary<string, Dictionary<string, int>> venues = new Dictionary<string, Dictionary<string, int>>();

            Regex regexSrubsko = new Regex(@"([A-Za-z\s]+)\s@([A-Za-z\s]+)\s(\d+)\s(\d+)");
            //([A-Za-z\s]+)\s@([A-Za-z\s]+)\s(\d+)\s(\d+)

            string inputLine = Console.ReadLine();
            while (inputLine != "End")
            {
                var matchSrubsko = regexSrubsko.Match(inputLine);
                if (matchSrubsko.Success)
                {
                    string singer = matchSrubsko.Groups[1].Value;
                    string venue = matchSrubsko.Groups[2].Value;
                    int ticketsPrice = int.Parse(matchSrubsko.Groups[3].Value);
                    int ticketsCount = int.Parse(matchSrubsko.Groups[4].Value);

                    if (!venues.ContainsKey(venue))
                    {
                        venues[venue] = new Dictionary<string, int>();
                    }

                    if (!venues[venue].ContainsKey(singer))
                    {
                        venues[venue][singer] = 0;
                    }

                    venues[venue][singer] += ticketsCount*ticketsPrice;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var pair in venues)
            {
                //#{2*space}{singer}{space}->{space}{total money}
                Console.WriteLine(pair.Key);
                foreach (var singer in pair.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }
    }
}
