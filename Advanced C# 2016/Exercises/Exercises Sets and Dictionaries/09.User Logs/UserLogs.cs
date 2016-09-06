using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    public class UserLogs
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> userLogs =
                new Dictionary<string, Dictionary<string, int>>();

            string pattern = @"IP=(.*?) message=(.*) user=(.*)";
            Regex patternRegex = new Regex(pattern);

            string input = Console.ReadLine();
            while (input != "end")
            {
                Match match = patternRegex.Match(input);
                string userName = match.Groups[3].Value;
                string ip = match.Groups[1].Value;
                if (!userLogs.ContainsKey(userName))
                {
                    userLogs.Add(userName, new Dictionary<string, int>());
                }

                if (!userLogs[userName].ContainsKey(ip))
                {
                    userLogs[userName].Add(ip, 0);
                }

                userLogs[userName][ip]++;
                input = Console.ReadLine();
            }

            foreach (var user in userLogs.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}: ");
                int count = 1;
                foreach (var ip in user.Value)
                {
                    Console.Write($"{ip.Key} => {ip.Value}");

                    if (count == user.Value.Count)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(", ");
                    }

                    count++;
                }

                Console.WriteLine();
            }
        }
    }
}
