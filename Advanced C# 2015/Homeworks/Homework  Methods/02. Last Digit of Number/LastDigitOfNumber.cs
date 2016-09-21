using System;
class LastDigitOfNumber
{
    static void Main()
    {
        //Write a method that returns the last digit of a given integer as an English word. Test the method with different 
        //input values. Ensure you name the method properly.
        //Input    Output
        //512      two
        //1024     four
        //12309    nine

        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(GetLastDigitAsWord(number));
    }
    private static string GetLastDigitAsWord(int number)
    {
        string[] word = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int digit = number % 10;
        return word[digit];
    }
}