using System;
using System.Text.RegularExpressions;
class SeriesOfLetters
{
    static void Main()
    {
        //Write a program that reads a string from the console and replaces all series of consecutive identical letters 
        //with a single one.
        //Input	                    Output
        //aaaaabbbbbcdddeeeedssaa	abcdedsa

        string input = Console.ReadLine();
        //string pattern = @"(\w)\1*"; 
        string pattern = @"(.)\1+";

        Regex rgx = new Regex(pattern);
        string letter = Regex.Replace(input, pattern, "$1");

        Console.WriteLine(letter);
    }
}