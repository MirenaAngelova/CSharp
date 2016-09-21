﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class WordCount
{
    static Dictionary<string, int> ReadDictionary()
    {
        string[] words;
        Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
        using (StreamReader reader = new StreamReader(@"..\..\words.txt"))
        {
            while (!reader.EndOfStream)
            {
                words = reader.ReadLine().ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in words)
                {
                    if (char.IsLetter(s[s.Length - 1]))
                    {
                        dictionary.Add(s, 0);
                    }
                    else
                    {
                        dictionary.Add(s.Substring(0, s.Length - 2), 0);
                    }
                }
            }
        }
        return dictionary;
    }
    static void CountWordInLine(string line, Dictionary<string, int> dictionary)
    {
        string[] input = line.ToLower().Split(new string[] { ",", ".", " " }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length; i++)
        {
            string key;
            if (char.IsLetter(input[i][input[i].Length - 1]))
            {
                key = input[i];
            }
            else
            {
                key = input[i].Substring(0, input[i].Length - 2);
            }
            if (dictionary.ContainsKey(key))
            {
                dictionary[key]++;
            }
        }
    }
    static void Main()
    {
        //Write a program that reads a list of words from the file words.txt and finds how many times each of the words is 
        //contained in another file text.txt. Matching should be case-insensitive.
        //Write the results in file results.txt. Sort the words by frequency in descending order. Use StreamReader 
        //in combination with StreamWriter.
        //words.txt	    text.txt	                                            result.txt
        //quick         -I was quick to judge him, but it wasn't his fault.     is - 3
        //is                                                                    quick - 2
        //fault	        -Is this some kind of joke?! Is it?                     fault - 1
        //              -Quick, hide here…It is safer.	

        Dictionary<string, int> dictionary;
        try
        {
            dictionary = ReadDictionary();
        }
        catch (Exception ex)
        {

            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        try
        {
            using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    CountWordInLine(reader.ReadLine(), dictionary);
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
            {
                foreach (KeyValuePair<string, int> item in dictionary.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
            Console.WriteLine(ex.StackTrace);
            return;
        }
        Console.WriteLine("Task complete:");

        Console.WriteLine("\nInput file:");
        string inputContents = File.ReadAllText(@"..\..\text.txt");
        Console.WriteLine(inputContents);

        Console.WriteLine("\nWords file:");
        string dictionaryContents = File.ReadAllText(@"..\..\words.txt");
        Console.WriteLine(dictionaryContents);

        Console.WriteLine("\nOutput file:");
        string outputContents = File.ReadAllText(@"..\..\result.txt");
        Console.WriteLine(outputContents);
    }
}