using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Logs_Aggregator
{
    public class LogsAgregator
    {
        public static void Main()
        {
            Dictionary<string, int> usersDuration = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> usersIP = new Dictionary<string, HashSet<string>>();
            // can use SortedSet instead HashSet
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                
                string user = input[1];
                int duration = int.Parse(input[2]);
                string ip = input[0];

                if (!usersDuration.ContainsKey(user))
                {
                    usersDuration.Add(user, 0);
                }

                usersDuration[user] += duration;

                if (!usersIP.ContainsKey(user))
                {
                    usersIP.Add(user, new HashSet<string>());
                }

                usersIP[user].Add(ip);
            }

            foreach (var user in usersDuration.OrderBy(u => u.Key))
            {
                Console.Write($"{user.Key}: {user.Value} [");
                var orderedUsersIP = usersIP[user.Key].OrderBy(u => u);


                //int count = 1;
                //foreach (var u in orderedUsersIP)
                //{
                //    Console.Write($"{u}");
                //    if (count == orderedUsersIP.Count())
                //    {
                //        Console.Write("]");
                //    }
                //    else
                //    {
                //        Console.Write(", ");
                //        count++;
                //    }
                //}

                Console.WriteLine(string.Join(", ", orderedUsersIP) + "]");
            }
        }
    }
}