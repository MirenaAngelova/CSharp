using System;
using System.Text;
class DecimalToHexadecimalNumber
{
    static string DecToHex(long dec)
    {
        //Using loops write a program that converts an integer number to its hexadecimal representation. 
        //The input is entered as long. The output should be a variable of type string. 
        //Do not use the built-in .NET functionality. Examples:
        //decimal	    hexadecimal
        //254	        FE
        //6883	        1AE3
        //338583669684	4ED528CBB4
        var sBuilder = new StringBuilder();
        while (dec > 0)
        {
            var num = dec % 16;
            dec /= 16;
            sBuilder.Insert(0, ((int)num).ToString("X"));
        }
        return sBuilder.ToString();
    }
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        string output = DecToHex(n);
        Console.WriteLine(output);
    }
}

