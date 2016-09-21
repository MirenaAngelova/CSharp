using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Rage_Quit
{
    class RageQuit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            // Don't use HashSet
            //string symbols = Regex.Replace(input, "\\d+", String.Empty).ToUpper();
            //HashSet<string> unique = new HashSet<string>();
            //foreach (var symbol in symbols)
            //{
            //    unique.Add(symbol.ToString());
            //}

            //Regex  stringNumberPairs = new Regex(@"([.+?\D+]+)(\d+)");
            Regex  stringNumberPairs = new Regex(@"(\D+)(\d+)");

            var matchRegex = stringNumberPairs.Matches(input);
            StringBuilder result = new StringBuilder();
            
            foreach (Match match in matchRegex)
            {
                string str = match.Groups[1].Value.ToUpper();
                int numberPairs = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < numberPairs; i++)
                {
                    result.Append(str);
                }
            }
            var unique = result.ToString().Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}", unique);
            Console.WriteLine(result.ToString());
        }
    }
}
