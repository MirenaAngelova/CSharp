using System;
using System.Linq;
class TextFilter
{
    static void Main()
    {
        //Write a program that takes a text and a string of banned words. All words included in the ban list should be 
        //replaced with asterisks "*", equal to the word's length. The entries in the ban list will be separated by 
        //a comma and space ", ".
        //The ban list should be entered on the first input line and the text on the second input line. Example:
        //Input	                                                Output
        //Linux, Windows                                        It is not *****, it is GNU/*****. ***** is merely the kernel,
        //It is not Linux, it is GNU/Linux. Linux is merely     while GNU adds the functionality. Therefore we owe it
        //the kernel, while GNU adds the functionality.         to them by calling the OS GNU/*****! Sincerely, 
        //Therefore we owe it to them by calling                a ******* client
        //the OS GNU/Linux! Sincerely, a Windows client	  

        string[] banList = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        //text = banList.Aggregate(text, (current, word) => current.Replace(word, new string('*', word.Length)));

        for (int i = 0; i < banList.Length; i++)
        {
            text = text.Replace(banList[i], new string('*', banList[i].Length));
        }

        Console.WriteLine(text);
    }
}