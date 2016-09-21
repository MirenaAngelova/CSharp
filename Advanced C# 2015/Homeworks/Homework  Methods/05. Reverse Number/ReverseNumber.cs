using System;
using System.Linq;
class ReversNumber
{
    static void Main()
    {
        //Write a method that reverses the digits of a given floating-point number.
        //Input    Output
        //256      652
        //123.45   54.321
        //0.12     21

        double floatingPoint = double.Parse(Console.ReadLine());
        double reversed = GetReversedNumber(floatingPoint);

        Console.WriteLine(reversed);
    }
    private static double GetReversedNumber(double num)
    {
        var reverse = num.ToString().Reverse();
        string number = string.Join("", reverse);

        num = double.Parse(number);

        return num;
    }
}
