using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
class ActivityTracker
{
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        //SortedDictionary<int, SortedDictionary<string, List<double>>> inputData =
        //    new SortedDictionary<int, SortedDictionary<string, List<double>>>();

        //SortedDictionary<int, SortedSet<string>> output = new SortedDictionary<int, SortedSet<string>>();

        //int n = int.Parse(Console.ReadLine());

        //for (int i = 0; i < n; i++)
        //{
        //    string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //    int month = DateTime.Parse(input[0]).Month;
        //    string user = input[1];
        //    double distance = double.Parse(input[2]);

        //    if (!inputData.ContainsKey(month))
        //    {
        //        SortedDictionary<string, List<double>> users = new SortedDictionary<string, List<double>>();

        //        List<double> distances = new List<double>();

        //        distances.Add(distance);
        //        users.Add(user, distances);
        //        inputData.Add(month, users);
        //    }
        //    else if (inputData.ContainsKey(month))
        //    {
        //        if (!inputData[month].ContainsKey(user))
        //        {
        //            List<double> distances = new List<double>();

        //            distances.Add(distance);
        //            inputData[month].Add(user, distances);
        //        }
        //        else if (inputData[month].ContainsKey(user))
        //        {
        //            inputData[month][user].Add(distance);
        //        }
        //    }
        //}

        //foreach (var pair1 in inputData)
        //{
        //    SortedSet<string> usersInfo = new SortedSet<string>();

        //    foreach (var pair2 in pair1.Value)
        //    {
        //        string userInfo = pair2.Key + "(" + pair2.Value.Aggregate((a, b) => b + a) + ")";

        //        usersInfo.Add(userInfo);
        //    }

        //    output.Add(pair1.Key, usersInfo);
        //}

        //foreach (var pair in output)
        //{
        //    Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
        //}

        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        SortedDictionary<int, SortedDictionary<string, double>> months =
            new SortedDictionary<int, SortedDictionary<string, double>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int month = DateTime.Parse(input[0]).Month;
            string user = input[1];
            double distance = double.Parse(input[2]);
            if (!months.ContainsKey(month))
            {
                months.Add(month, new SortedDictionary<string, double>());
            }
            if (!months[month].ContainsKey(user))
            {
                months[month].Add(user, 0);
            }
            months[month][user] += distance;

        }
        foreach (var month in months)
        {
            Console.Write($"{month.Key}: ");
            int count = 0;

            foreach (var user in month.Value)
            {
                count++;
                Console.Write($"{user.Key}({user.Value})");
                if (month.Value.Count != count)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}

