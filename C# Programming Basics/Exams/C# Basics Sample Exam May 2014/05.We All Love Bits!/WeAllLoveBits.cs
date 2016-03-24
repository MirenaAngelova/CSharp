using System;
class WeAllLoveBits
{
    static void Main()
    {
        //One of the things the programmers love the most is bitwise operations. The "bitwise guy" is a synonym 
        //for a programmer that loves bits more than everything else in programming. Mitko is a "bitwise guy". 
        //He invented a new bitwise algorithm. The algorithm takes one positive integer number P, 
        //makes magic with it and returns a new positive integer number. He also defined a new number P̃ which 
        //represents the number P in binary numeral system with inverted bits. All zeros in P are ones in P̃ 
        //and all ones in P are zeros in P̃. For example if we have P = 9 (which is 1001 in binary numeral system) 
        //its inverted number P̃ will be equal to 6 (which is 110 in binary numeral system). But that’s not all! 
        //He invented another number P̈, which represents reversed number P in binary numeral system. 
        //For example if we have P = 11 (which is 1011 in binary numeral system) its reversed number P̈ is equal to 13 
        //(which is 1101 in binary numeral system). The Mitko's magical algorithm takes a number P and 
        //transforms it to a new number Pnew using the following bitwise transformation: Pnew = (P ^ P̃) & P̈.
        //Your task is to write a program that transforms a sequence of N positive integer numbers using Mitko's algorithm.
        //Input
        //•	The input data should be read from the console.
        //•	At the first input line there will be one positive integer – the number N.
        //•	At each of the next N lines there will be one positive integer – the consequent number that must be converted 
        //using Mitko's algorithm.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data should be printed on the console.
        //•	The output must consist of N lines, containing the transformed numbers for each number from the input.
        //Constraints
        //•	The number N will be positive integer number between 1 and 20 000, inclusive.
        //•	Each of the N numbers will be positive integer numbers between 1 and 2 147 483 647, inclusive.
        //•	Time limit: 0.20 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output		Input	Output		Input	    Output
        //1     1           2       25          4           3894963
        //2		            19	    31          6732654     255
        //                  248                 255         8125777
        //	                                    36372344    1623
        //		                                60000	
        //
        //Attribution: this work may contain portions from the "C# Part I" course by Telerik Academy under CC-BY-NC-SA license.

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            uint p = uint.Parse(Console.ReadLine());
            uint newP = 0;
            
            while (p > 0)
            {
                newP = newP << 1;
                if ((p & 1) == 1)
                {
                    newP = newP | 1;
                }
                p = p >> 1;
            }
            Console.WriteLine(newP);
        }



        //int n = int.Parse(Console.ReadLine());
        //uint rev = 0;
        //for (int i = 0; i < n; i++)
        //{
        //    uint number = uint.Parse(Console.ReadLine());
        //    while (number > 0)
        //    {
        //        rev <<= 1;
        //        rev |= (number & 1);
        //        number >>= 1;
        //    }
        //    Console.WriteLine(rev);
        //    rev = 0;
        //}
    }
}






