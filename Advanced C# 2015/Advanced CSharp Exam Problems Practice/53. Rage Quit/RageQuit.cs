using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class RageQuit
{
    static void Main()
    {
        Regex pairMatcher = new Regex(@"(\D+)(\d+)");

        string singleLine = Console.ReadLine();

        Match pair = pairMatcher.Match(singleLine);

        StringBuilder sb = new StringBuilder();

        do
        {
            string str = pair.Groups[1].Value.ToUpper();
            int digit = int.Parse(pair.Groups[2].Value);

            for (int i = 0; i < digit; i++)
            {
                sb.Append(str);
            }

            pair = pair.NextMatch();

        } while (pair.Success);

        int uniqueSymbols = sb.ToString().Distinct().Count();

        Console.WriteLine("Unique symbols used: {0}", uniqueSymbols);
        Console.WriteLine(sb);
    }
}