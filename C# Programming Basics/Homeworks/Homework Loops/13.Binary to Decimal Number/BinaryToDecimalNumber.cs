using System;
class BinaryToDecimalNumber
{
    static void Main()
    {
        //Using loops write a program that converts a binary integer number to its decimal form. 
        //The input is entered as string. The output should be a variable of type long. 
        //Do not use the built-in .NET functionality. Examples:
        //binary	                    decimal
        //0	                            0
        //11	                        3
        //1010101010101011	            43691
        //1110000110000101100101000000	236476736

        string n = Console.ReadLine();
        long output = 0L;
        for (int i = 0; i < n.Length; i++)
        {
            if (n[n.Length - i -1] != '0')
            {
                output += (long)Math.Pow(2, i);
            }
        }
        Console.WriteLine(output);
    }
}

