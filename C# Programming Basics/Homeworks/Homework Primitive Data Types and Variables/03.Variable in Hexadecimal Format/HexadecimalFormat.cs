using System;
class HexadecimalFormat
{
    static void Main()
    {
        //Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##). 
        //Use Windows Calculator to find its hexadecimal representation. 
        //Print the variable and ensure that the result is “254”.

        //int number = 254;
        //Console.WriteLine("The hexadecimal represantation of number 254 is: {0:X}", number);

        int nDec = 254;
        string nHex = nDec.ToString("X");
        Console.WriteLine(nHex);
    }
}

