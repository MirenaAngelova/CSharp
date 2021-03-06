﻿using System;
class HalfByteSwapper
{
    static void Main()
    {
        //You are given four 32 bit integer numbers. Your task is to swap groups of 4 bits between the 4 numbers. 
        //You will be given series of commands. Commands end when the last command given is "End". 
        //Each command consists of 2 lines each holding 2 numbers separated by space. The first number 
        //in the command shows which number (0 -3) will be manipulated and the second number which group (0-7) of 4 bits 
        //will be swapped. The 2 lines in each command show the 2 numbers that will swap groups of 4 bits. 
        //Print the four numbers after all commands have been executed. 
        //See the examples on the right to understand you task better. 
        //Input
        //Input data is read from the console.
        //•	On the first 4 lines you will be given 4 32 bit integer numbers
        //•	On each of the next 2 lines will be a single command showing the 2 numbers and groups that will swap bits.
        //•	On the last line on the input will be given the command "End" indicting no more commands will be given
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	Print the 4 input numbers on separate line after all commands are executed
        //Constraints
        //•	The 4 input numbers will be in the range [0... 4, 294,967,295].
        //•	The first number in the command will be between [0-3] and the second between [0-7] 
        //•	Time limit: 0.25 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output		Input	Output		Input	    Output		Input	Output
        //15    1           165     165         15          15          0       1111
        //165   165         37584   852480      983040      15          327680  0
        //1001  1001        53      53          15728640    15          1792	0 
        //784   1008        2345    9439529     251658240   15          262144  0
        //0 0               1 3                 1 4                     1 4
        //3 1               3 5                 1 0                     0 1
        //End	            1 1                 2 5                     2 2
        //                  1 4                 2 0                     0 0
        //                  End	                3 6                     3 4
        //                                      3 0                     0 2
        //		                                End                     End	 

        uint[] numbers = new uint[4];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }
        while (true)
        {
            string[] from = Console.ReadLine().Split(' ');
            if (from[0] == "End")
            {
                break;
            }
            string[] to = Console.ReadLine().Split(' ');
            int firstN = int.Parse(from[0]);
            int secondN = int.Parse(to[0]);
            int firstG = int.Parse(from[1]) * 4;
            int secondG = int.Parse(to[1]) * 4;

            uint fromM = 15u << firstG;
            uint toM = 15u << secondG;
            uint fromB = (numbers[firstN] & fromM) >> firstG;
            uint toB = (numbers[secondN] & toM) >> secondG;

            numbers[firstN] &= ~fromM;
            numbers[secondN] &= ~toM;

            numbers[firstN] |= toB << firstG;
            numbers[secondN] |= fromB << secondG;
        }
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

