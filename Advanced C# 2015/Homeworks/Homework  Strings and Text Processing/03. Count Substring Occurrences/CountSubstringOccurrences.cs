using System;
using System.Linq;
class CountSubstringOccurrences
{
    static void Main()
    {
        //Write a program to find how many times a given string appears in a given text as substring. 
        //The text is given at the first input line. The search string is given at the second input line. 
        //The output is an integer number. Please ignore the character casing. Overlapping between occurrences is allowed. 
        //Examples:
        //Input	                                                                        Output
        //Welcome to the Software University (SoftUni)! Welcome to programming.         4
        //Programming is wellness for developers, said Maxwell.
        //wel	
        //aaaaaa                                                                        5
        //aa	
        //ababa caba                                                                    3
        //aba	
        //Welcome to SoftUni                                                            0
        //Java	

        //string text = Console.ReadLine();
        //string substring = Console.ReadLine();

        //int apperance = text.Select((c, i) => text.Substring(i))
        //    .Count(x => x.StartsWith(substring, StringComparison.CurrentCultureIgnoreCase));
        //Console.WriteLine(apperance);

        string text = Console.ReadLine().ToLower();
        string substring = Console.ReadLine().ToLower();
        int apperance = 0;

        for (int i = 0; i <= text.Length - substring.Length; i++)
        {
            string check = text.Substring(i, substring.Length);
            if (check == substring)
            {
                apperance++;
            }
        }
        Console.WriteLine(apperance);
    }
}