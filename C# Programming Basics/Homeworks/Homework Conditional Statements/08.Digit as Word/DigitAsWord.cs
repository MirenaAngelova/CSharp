using System;
class DigitAsWord
{
    static void Main()
    {
        //Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). 
        //Print “not a digit” in case of invalid input. Use a switch statement. Examples:
        //d     result
        //2	    two
        //1	    one
        //0	    zero
        //5	    five
        //-0.1	not a digit
        //hi	not a digit
        //9	    nine
        //10	not a digit

        string digits = Console.ReadLine();
        string digit;
        switch (digits)
        {
            case "0":
                digit = "zero";
                break;
            case "1":
                digit = "one";
                break;
            case "2":
                digit = "two";
                break;
            case "3":
                digit = "three";
                break;
            case "4":
                digit = "four";
                break;
            case "5":
                digit = "five";
                break;
            case "6":
                digit = "six";
                break;
            case "7":
                digit = "seven";
                break;
            case "8":
                digit = "eight";
                break;
            case "9":
                digit = "nine";
                break;
            default:
                   digit= "not a digit";
                   break;
        }
        Console.WriteLine(digit);
    }
}

