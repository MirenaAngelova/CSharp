using System;
using System.Collections.Generic;
using System.Linq;
class Palindromes
{
    static void Main()
    {
        //Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe and prints them 
        //on the console on a single line, separated by comma and space. Use spaces, commas, dots, question marks 
        //and exclamation marks as word delimiters. Print only unique palindromes, sorted lexicographically.
        //Example:
        //Input	                                    Output
        //Hi,exe? ABBA! Hog fully a string. Bob	    a, ABBA, exe

        char[] delimiters = { ' ', ',', '.', '?', '!' };
        SortedSet<string> palindromes = new SortedSet<string>();
        List<string> text = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (var word in text)
        {
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }
        Console.WriteLine(string.Join(", ", palindromes));
    }
    private static bool IsPalindrome(string word)
    {
        if (word.Length == 1)
        {
            return true;
        }
        int length = word.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (word[i] == word[length - i - 1])
            {
                return true;
            }
        }
        return false;
    }
}