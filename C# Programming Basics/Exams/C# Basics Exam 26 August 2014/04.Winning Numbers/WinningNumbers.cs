using System;
class WinningNumbers
{
    static void Main()
    {
        //We are given a string S consisting of capital and non-capital letters. Every letter has a value equal 
        //to its position in the English alphabet (a=1, b=2, …, z=26). 
        //First you have to calculate the sum of all letters letSum. 
        //Then, find all 6-digits numbers in range [000 000 … 999 999] called winning numbers for which the following 
        //is true: the product of the first three digits is equal to the product of the second three digits, 
        //and both of those are equal to letSum. Your task is to print on the console all winning numbers.
        //Input
        //The input data should be read from the console. It consists of 1 line:
        //•	On the first line you will be given a string S which will only consist of lower and capital case letters.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console as a sequence of winning numbers in format abc-def in ascending order. 
        //Each winning number should stay alone on a separate line. In case there are no winning numbers, print “No”.
        //Constraints
        //•	The string S will have maximal length of 150 characters.
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output	    Comments		                                        Input	        Output		
        //aa	112-112     The sum of aa = 2.                                      xz	            255-255
        //      112-121     The first output has product of the first 3 digits                      255-525
        //      112-211     1*1*2 = 2 and second 3 digits have product 1*1*2 = 2.                   255-552 
        //      121-112     The same product 2 is obtained in all other output s.                   525-255
        //      121-121                                                                             525-525
        //      121-211                                                                             525-552
        //      211-112                                                                             552-255
        //      211-121                                                                             552-525
        //      211-211	                                                                            552-552
        //
        //Input	    Output	
        //177-177	cobazaa
        //177-717   	
        //177-771
        //717-177
        //717-717
        //717-771
        //771-177
        //771-717
        //771-771

        string input = Console.ReadLine();
        int letSum = 0;
        string upper = input.ToUpper();
        for (int i = 0; i < input.Length; i++)
        {
            letSum += upper[i] - 'A' + 1;
        }
        int count = 0;
        for (int a = 0; a <= 9; a++)
        {
            for (int b = 0; b <= 9; b++)
            {
                for (int c = 0; c <= 9 ; c++)
                {
                    for (int d = 0; d <= 9; d++)
                    {
                        if (a * b * c == letSum)
	                    {
		                     for (int e = 0; e <= 9; e++)
                            {
                                for (int f = 0; f <= 9; f++)
                                {
                                    if (e * d * f == letSum)
                                    {
                                        Console.WriteLine("{0}{1}{2}-{3}{4}{5}", a, b, c, d, e, f);
                                        count++;
                                    }
                                }
                            }
	                    }
                    }
                }
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}

