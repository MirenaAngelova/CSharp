using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _57.Valid_Usernames
{
    class ValidUsername
    {
        static void Main(string[] args)
        {//only letters, digits and “_”. It cannot be less than 3 or more than 25 
            string input = Console.ReadLine();
            string pattern = "([\\s\\/\\\\(\\)]*)([A-Za-z][\\w]{3,25})";
            
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);
            int sum = 0;
            int maxSum = 0;
            int index = 0;
            for (int i = 0; i < matches.Count - 1; i++)
            {
                
                string usernameFirst = matches[i].Groups[2].ToString();
                string usernameSecond = matches[i + 1].Groups[2].ToString();
                sum = usernameFirst.Length + usernameSecond.Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                }
            }

            Console.WriteLine(matches[index].Groups[2]);
            Console.WriteLine(matches[index + 1].Groups[2]);
        }
    }
}
