using System;
using System.Collections.Generic;
using System.Linq;
class CountSymbols
{
    static void Main()
    {
        //Write a program that reads some text from the console and counts the occurrences of each character in it. 
        //Print the results in alphabetical (lexicographical) order. Examples:
        //Input	            Output
        //SoftUni rocks	     : 1 time/s     Did you know Math.Round rounds to the nearest even integer?	 : 9 time/s
        //                  S: 1 time/s                                                                 .: 1 time/s
        //                  U: 1 time/s                                                                 ?: 1 time/s
        //                  c: 1 time/s                                                                 D: 1 time/s
        //                  f: 1 time/s                                                                 M: 1 time/s
        //                  i: 1 time/s                                                                 R: 1 time/s
        //                  k: 1 time/s                                                                 a: 2 time/s
        //                  n: 1 time/s                                                                 d: 3 time/s
        //                  o: 2 time/s                                                                 e: 7 time/s
        //                  r: 1 time/s                                                                 g: 1 time/s
        //                  s: 1 time/s                                                                 h: 2 time/s
        //                  t: 1 time/s                                                                 i: 2 time/s
        //                                                                                              k: 1 time/s
        //                                                                                              n: 6 time/s
        //                                                                                              o: 5 time/s
        //                                                                                              r: 3 time/s
        //                                                                                              s: 2 time/s
        //                                                                                              t: 5 time/s
        //                                                                                              u: 3 time/s
        //                                                                                              v: 1 time/s
        //                                                                                              w: 1 time/s
        //                                                                                              y: 1 time/s
        //Uvh34yt78y78y7Y&T^^DFt362t62thfwuihhYG&GY2	&: 2 time/s
        //2: 3 time/s
        //3: 2 time/s
        //4: 1 time/s
        //6: 2 time/s
        //7: 3 time/s
        //8: 2 time/s
        //D: 1 time/s
        //F: 1 time/s
        //G: 2 time/s
        //T: 1 time/s
        //U: 1 time/s
        //Y: 3 time/s
        //^: 2 time/s
        //f: 1 time/s
        //h: 4 time/s
        //i: 1 time/s
        //t: 4 time/s
        //u: 1 time/s
        //v: 1 time/s
        //w: 1 time/s
        //y: 3 time/s

        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        string input = Console.ReadLine();

        CountAllSymbols(ref symbols, input);
        PrintSymbols(symbols);
    }

    public static void CountAllSymbols(ref SortedDictionary<char, int> symbols, string input)
    {
        HashSet<char> selected = new HashSet<char>();

        int length = input.Length;
        int count;
        char symbol = '\0';

        for (int i = 0; i < length; i++)
        {
            symbol = input[i];

            if (!selected.Contains(symbol))
            {
                count = input.Count(x => x == symbol);
                symbols.Add(symbol, count);
                selected.Add(symbol);
            }
        }
    }

    public static void PrintSymbols(SortedDictionary<char, int> symbols)
    {
        foreach (var item in symbols)
        {
            Console.WriteLine(item.Key + ": " + item.Value + " time/s");
        }
    }
}