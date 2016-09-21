using System;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string input = Console.ReadLine();
        string text = null;
        while (input != "END")
        {
            text += input;
            input = Console.ReadLine();
        }
        MatchCollection hyperlinks = Regex.Matches(text, "<a[^>]*(href\\s*=)(\\s*)(\".*?\"|[\\w\\s'\\/][^><\\s]*)");
        foreach (Match link in hyperlinks)
        {
            Console.WriteLine(link.Groups[3].ToString().Trim(new char[] { '\"', '\'' }));
        }
    }
}