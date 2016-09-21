using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28.Logs_Aggregator
{
    class LogsAgregator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedSet<string>> users =
                new SortedDictionary<string, SortedSet<string>>();
            Dictionary<string, int> durations = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);
                if (!users.ContainsKey(user))
                {
                    users.Add(user, new SortedSet<string>());
                    durations[user] = 0;
                }

                users[user].Add(ip);
                durations[user] += duration;
            }

            foreach (var user in users)
            {//peter: 303 [10.10.17.34, 10.10.17.35, 192.168.0.11]
                Console.WriteLine($"{user.Key}: {durations[user.Key]} " +
                                  $"[{string.Join(", ", user.Value)}]");
            }
        }
    }
}
