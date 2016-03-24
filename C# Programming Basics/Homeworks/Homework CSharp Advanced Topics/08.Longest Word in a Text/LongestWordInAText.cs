using System;
using System.Linq;
class LongestWordInAText
{
    static void Main()
    {
        //Write a program to find the longest word in a text. Examples:
        //Input	                                        Output
        //Welcome to the Software University.	        University
        //The C# Basics course is awesome start 	    programming
        //in programming with C# and Visual Studio.

        string[] text = Console.ReadLine().Split(new char[] {' ', '.'});
        var longestWord = text.Where(x => x.Length == text.Max(y => y.Length)).First();
        Console.WriteLine(longestWord);
    }
}

