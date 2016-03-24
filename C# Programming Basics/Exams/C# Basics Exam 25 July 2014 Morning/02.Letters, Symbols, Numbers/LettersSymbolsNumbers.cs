using System;
using System.Text.RegularExpressions;
class LettersSymbolsNumbers
{
    static void Main()
    {
        //You are given N strings. Every string consists of letters, symbols, numbers and whitespace. 
        //All letters (a-z) and (A-Z) have values corresponding to their position 
        //in the English alphabet * 10 (a = 10, A = 10, b = 20, B = 20, …, z = 260, Z = 260). 
        //All symbols (like `~!@#$%^&*()_+{}:"|<>?-=[];'\,./) have a fixed value of 200 and all numbers 
        //have the value of their digit * 20 (0 = 0, 1 = 20, 2 = 40, 3 = 60, …, 9 = 180). 
        //The whitespace is ignored. Your task is to calculate the sum of all letters, 
        //all symbols and all numbers from the input and print them, each at a separate line.
        //Input
        //The input data should be read from the console.
        //•	At the first line an integer number N is given, specifying the count of the input strings.
        //•	Each of the next N lines holds an input string.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of exactly 3 lines:
        //•	On the first line print the sum of all letters.
        //•	On the second line print the sum of all numbers.
        //•	On the third line print the sum of all symbols.
        //Constraints
        //•	N is an integer between in range [0… 1000].
        //•	All of the strings combined have a maximal length of 255 000 characters.
        //•	All characters, which are not Latin letters or whitespace, are considered symbols.
        //•	The whitespace are the symbols ' ', '\t', '\r' and '\n'.
        //•	Allowed working time for your program: 0.2 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	        Output	Comments
        //1             810     The string has 6 letters: 3*a + 3*z = 3*10 + 3*260 = 30+780 = 810;
        //aaa.zzz.123	120     3 numbers: (1+2+3) * 20 = 120 and 2 symbols (dots): 2 * 200 = 400.
        //              400
        //	 

        //Input	                Output		Input	            Output		Input	                    Output
        //3                     5440        4                   0           10                          18130
        //SoftUni – practical   0           374687697641        2660        The Software                140
        //software development  600         %^^&%&^&#^$&%&*     6200        University (SoftUni)        1400
        //training + job!	                9997557.,.,.,                   provides quality
        //                                  %^6^44^&*$_+_	                practical education,
        //		                                                            profession and a job
        //                                                                  for thousands young
        //                                                                  people who become
        //                                                                  skillful software
        //                                                                  engineers.
        //                                                                  -- Nakov, July 2014	

        int n = int.Parse(Console.ReadLine());
        long lettersSum = 0;
        long numbersSum = 0;
        long symbolsSum = 0;
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            input = input.ToUpper();
            input = Regex.Replace(input, "\\s+", "");
            for (int j = 0; j < input.Length; j++)
            {
                char current = input[j];
                if ((current >= 'A') & (current <= 'Z'))
                {
                    lettersSum += (current - 'A' + 1) * 10;
                }
                else if ((current >= '0') & (current <= '9')) 
                {
                    numbersSum += (current - '0') * 20;
                }
                else
                {
                    symbolsSum += 200;
                }
            }
        }
        Console.WriteLine(lettersSum);
        Console.WriteLine(numbersSum);
        Console.WriteLine(symbolsSum);
    }
}

