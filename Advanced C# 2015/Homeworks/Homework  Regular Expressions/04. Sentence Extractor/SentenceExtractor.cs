using System;
using System.Text.RegularExpressions;
class SentenceExtractor
{
    static void Main()
    {
        //Write a program that reads a keyword and some text from the console and prints all sentences from the text, 
        //containing that word. A sentence is any sequence of words ending with '.', '!' or '?'. Examples:
        //Input	                                                                    Output
        //is                                                                        This is my cat!
        //This is my cat! And this is my dog. We happily live in Paris – the        And this is my dog.
        //most beautiful city in the world! Isn’t it great? Well it is :)	

        string keyword = string.Format(@"\b{0}\b", Console.ReadLine());
        string pattern = @"[^.!?]*" + keyword + @"[^.!?]*[.!?]";

        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

        string text = Console.ReadLine();
        Match m = rgx.Match(text);

        while (m.Success)
        {
            Console.WriteLine(m.Value.Trim());
            m = m.NextMatch();
        }
    }
}