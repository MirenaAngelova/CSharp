using System;
class ThirdDigitIsSeven
{
    static void Main()
    {
        //Write an expression that checks for given integer if its third digit from right-to-left is 7. Examples:
        //n	        Third digit 7?
        //5	        false
        //701	    true
        //9703	    true
        //877	    false
        //777877	false
        //9999799	true

        int integer = int.Parse(Console.ReadLine());
        bool isSeven = true;
        integer = integer / 100;
        if (integer % 10 == 7)
        {
            Console.WriteLine(isSeven);
        }
        else
        {
            Console.WriteLine(!isSeven);
        }
    }
}

