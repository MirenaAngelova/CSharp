using System;
using System.Linq;
using System.Text.RegularExpressions;

class TerroristsWin
{
    static void Main()
    {
        //string text = Console.ReadLine();

        //int firstPipe = text.IndexOf('|');
        //int secondPipe = 0;

        //int sum = 0;
        //int lastDigit = 0;

        //while (firstPipe != -1)
        //{
        //    secondPipe = text.IndexOf('|', firstPipe + 1);
        //    int bombLength = secondPipe - firstPipe - 1;

        //    string bomb = text.Substring(firstPipe + 1, bombLength);

        //    foreach (var item in bomb)
        //    {
        //        sum += (char)item;
        //    }

        //    lastDigit = sum % 10;

        //    int startIndex = firstPipe - lastDigit;
        //    int endIndex = secondPipe + lastDigit;

        //    startIndex = startIndex > 0 ? startIndex : 0;
        //    endIndex = endIndex < text.Length ? endIndex : text.Length - 1;

        //    int destroyedArea = endIndex - startIndex + 1;

        //    text = text.Remove(startIndex, destroyedArea).Insert(startIndex, new string('.', destroyedArea));

        //    firstPipe = text.IndexOf('|', secondPipe + 1);
        //    sum = 0;
        //}

        //Console.WriteLine(text);

        //de_dust2 |A| the best |BB|map!
        string input = Console.ReadLine();
        string patternBomb = "\\|(.*?)\\|";//@"\\|(.*?)\\|" match empty string
        Regex rgx = new Regex(patternBomb);
        MatchCollection matches = rgx.Matches(input);

        foreach (Match match in matches)
        {
            char[] bomb = match.Groups[1].Value.ToCharArray();
            long sum = bomb.Aggregate<char, long>(0, (current, b) => current + b);
            char sumList = sum.ToString().Last();
            int bombPower = int.Parse(sumList.ToString());
            string adjacentBomb = ".{0," + bombPower + "}\\|(.*?)\\|.{0," + bombPower + "}";
            Regex regex = new Regex(adjacentBomb);
            Match m = regex.Match(input);
            if (m != Match.Empty)
            {
                string dots = m.Value;
                string d = String.Empty;
                for (int i = 0; i < dots.Length; i++)
                {
                    d += ".";
                }
                input = input.Replace(dots, d);
            }
        }
        //de_d.............bes........p!
        Console.WriteLine(input);
    }
}