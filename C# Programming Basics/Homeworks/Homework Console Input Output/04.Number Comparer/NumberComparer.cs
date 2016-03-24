using System;
class NumberComparer
{
    static void Main()
    {
        //Write a program that gets two numbers from the console and prints the greater of them. 
        //Try to implement this without if statements. Examples:
        //a	   b	greater
        //5	   6	6
        //10   5	10
        //0	   0	0
        //-5   -2	-2
        //1.5  1.6	1.6

        Console.WriteLine("Enter number \"a\": ");
        //int a = int.Parse(Console.ReadLine());
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number \"b\": ");
        //int b = int.Parse(Console.ReadLine());
        //int max = a - ((a - b) & ((a - b) >> 31));
        //Console.WriteLine("The greater number is: {0}", max);
        double b = double.Parse(Console.ReadLine());
        //Console.WriteLine("The greater number is: {0}", (a + b + Math.Abs(a - b)) / 2);
        Console.WriteLine("The greater number is: {0}", Math.Max(a, b));   
    }
}

