using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _24.User_Logs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> users =
               new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                //if has whitespaces everywhere
                //string inputLine = new Regex(input.Replace(@"\d*", String.Empty)).ToString();
                //string inputLine = new Regex("\\d*").Replace(input, string.Empty);

                string[] inputLine = input
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string user = new Regex("user=").Replace(inputLine[2], string.Empty);
                string ip = new Regex(inputLine[0].Replace(@"IP=", String.Empty)).ToString();
                //string user = inputLine[2].Replace("user=", string.Empty);
                //string ip = inputLine[0].Replace("IP=", string.Empty);
                //int message = 1;
                int message = 0;

                if (!users.ContainsKey(user))
                {
                    //users[user] = new Dictionary<string, int>();
                    users.Add(user, new Dictionary<string, int>());
                }

                if (!users[user].ContainsKey(ip))
                {
                    //users[user][ip] = 0;
                    users[user].Add(ip, message);
                }

                //users[user][ip] += 1;
                users[user][ip] += message + 1;

                input = Console.ReadLine();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: ");
                int counter = 0;
                foreach (var ip in user.Value)
                {
                    counter++;
                    string delim = string.Empty;
                    delim = user.Value.Count == counter ? "." : ", ";
                    Console.Write($"{ip.Key} => {ip.Value}" + delim);
                }

                Console.WriteLine();
            }
        }
    }
}
