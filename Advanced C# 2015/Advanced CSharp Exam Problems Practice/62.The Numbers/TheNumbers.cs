using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _62.The_Numbers
{
    class TheNumbers
    {
        static void Main(string[] args)
        {
            //5tffwj(//*7837xzc2---34rlxXP%$
            string input = Console.ReadLine();
            string pattern = "[0-9]+";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);
            int counter = 0;
            foreach (Match match in matches)
            {
                counter++;
                int number = int.Parse(match.Value);
                Console.Write($"0x{number:X4}");
                if (matches.Count != counter)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
        }
    }
}
