using System;
class HexadecimalToDecimalNumber
{
    static void Main()
    {
        //Using loops write a program that converts a hexadecimal integer number to its decimal form. 
        //The input is entered as string. The output should be a variable of type long. 
        //Do not use the built-in .NET functionality. Examples:
        //hexadecimal	decimal
        //FE	        254
        //1AE3	        6883
        //4ED528CBB4	338583669684

        string hexadecimal = Console.ReadLine();
        int n = 0;
        long hexN = 0;
        long degree = hexadecimal.Length - 1;
        for (int i = 0; i < hexadecimal.Length; i++)
        {
            char ch = hexadecimal[i];
            switch (ch.ToString())
            {
                case "A":
                    n = 10;
                    break;
                case "B":
                    n = 11;
                    break;
                case "C":
                    n = 12;
                    break;
                case "D":
                    n = 13;
                    break;
                case "E":
                    n = 14;
                    break;
                case "F":
                    n = 15;
                    break;
                default:
                    n = Convert.ToInt32(ch.ToString());
                    break;
            }
            hexN += n * (long)Math.Pow(16, degree);
            degree--;
        }
        Console.WriteLine(hexN);
    }
}

