using System;
class DecimalToBinaryNumber
{
    static void Main()
    {
        //Using loops write a program that converts an integer number to its binary representation. 
        //The input is entered as long. The output should be a variable of type string. 
        //Do not use the built-in .NET functionality. Examples:
        //decimal	    binary
        //0	            0
        //3	            11
        //43691	        1010101010101011
        //236476736	    1110000110000101100101000000

        long n = long.Parse(Console.ReadLine());
        string output = "";
        do
        {
            output = n % 2 + output;
            n /= 2;
        } while (n > 0);
        Console.WriteLine(output);
    }
}

