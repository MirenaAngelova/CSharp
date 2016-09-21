using System;
class BiggerNumber
{
    static void Main()
    {
        //Write a method GetMax() with two parameters that returns the larger of two integers. Write a program 
        //that reads 2 integers from the console and prints the largest of them using the method GetMax().
        //Input	    Output
        //4         4
        //-5	

        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        int max = GetMax(firstNumber, secondNumber);

        Console.WriteLine(max);
    }
    static int GetMax(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }
}