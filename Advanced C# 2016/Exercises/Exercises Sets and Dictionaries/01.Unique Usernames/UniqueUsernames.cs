using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsername = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                uniqueUsername.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, uniqueUsername));
        }
    }
}
