using System;
class MorseCodeNumbers
{
    static void Main()
    {
        //"Morse code" is a method of transmitting text information as a series of on-off tones / lights / clicks / etc. 
        //All symbols are represented by “.” (dots) and “-“ (dashes).
        //You are given a 4-digit number n (1000 ≤ n ≤ 9999). First, you have to calculate the sum of all digits 
        //of the number n called nSum. Write a program to generate all sequences of 6 numbers in the range 0…5, 
        //represented by their Morse code encodings 
        //(0 = “-----”, 1 = “.----”, 2 = “..---”, 3 = “...--”, 4 = “....-”, 5 = “.....”), 
        //such that the product of these 6 numbers is equal to nSum. This product is called morseProduct. 
        //Put “|” (pipe) as a separator after each Morse code digit. These sequences of strings are called “Morse code numbers”.
        //See the examples below for better understanding.
        //Input
        //•	The input data should be read from the console.
        //•	The number n stays at the first line.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console as a sequence of strings (Morse code numbers), each at a separate line. 
        //The order of the output lines is not important. In case no Morse code numbers exist, print “No”.
        //Constraints
        //•	The number n will be an integer number in the range [1000…9999].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output	                                Comments
        //1000	    .----|.----|.----|.----|.----|.----|	nSum = 1+0+0+0 = 1
        //                                                  morseProduct = 1*1*1*1*1 = 1

        //Input	    Output	                                Comments
        //1001	    .----|.----|.----|.----|.----|..---|    nSum = 1+0+0+1 = 2
        //          .----|.----|.----|.----|..---|.----|    morseProduct = 1*1*1*1*1*2 = 2
        //          .----|.----|.----|..---|.----|.----|    morseProduct = 1*1*1*1*2*1 = 2
        //          .----|.----|..---|.----|.----|.----|    morseProduct = 1*1*1*2*1*1 = 2
        //          .----|..---|.----|.----|.----|.----|    morseProduct = 1*1*2*1*1*1 = 2
        //          ..---|.----|.----|.----|.----|.----|    morseProduct = 1*2*1*1*1*1 = 2	
        //                                                  morseProduct = 2*1*1*1*1*1 = 2
        //Input	Output	Comments
        //1231	No	    nSum = 1+2+3+1 = 7
        //              No Morse code numbers match the condition

        int n = int.Parse(Console.ReadLine());
        int nSum = 0;
        while (n > 0)
        {
            nSum += n % 10;
            n /= 10;
        }
        string[] morseCode = { "-----", ".----", "..---", "...--", "....-", "....." };
        bool isEqual = false;
        for (int i0 = 0; i0 <= 5; i0++)
        {
            for (int i1 = 0; i1 <= 5; i1++)
            {
                for (int i2 = 0; i2 <= 5; i2++)
                {
                    for (int i3 = 0; i3 <= 5; i3++)
                    {
                        for (int i4 = 0; i4 <= 5; i4++)
                        {
                            for (int i5 = 0; i5 <= 5; i5++)
                            {
                                int morseProduct = i0 * i1 * i2 * i3 * i4 * i5;
                                if (morseProduct == nSum)
                                {
                                    string morseNumber = morseCode[i0] + "|" + morseCode[i1] + "|" + morseCode[i2] + "|"
                                                + morseCode[i3] + "|" + morseCode[i4] + "|" + morseCode[i5] + "|";
                                    isEqual = true;
                                    Console.WriteLine(morseNumber);
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!isEqual)
        {
            Console.WriteLine("No");
        }
    }
}



