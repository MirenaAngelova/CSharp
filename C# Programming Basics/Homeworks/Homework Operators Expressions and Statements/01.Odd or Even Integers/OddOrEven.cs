using System;
class OddOrEven
{
    static void Main()
    {
        //Write an expression that checks if given integer is odd or even. Examples:
        //n	    Odd?
        //3	    true
        //2	    false
        //-2    false
        //-1    true
        //0	    false

        int number = int.Parse(Console.ReadLine());
        bool isOdd = true;
        if (number % 2 == 0)
        {
            isOdd = false;
        }
        Console.WriteLine("{0}    {1}", number, isOdd);

        //int n = int.Parse(Console.ReadLine());
        //if (n % 2 == 0)
        //{
        //    Console.WriteLine("false");
        //}
        //else
        //{
        //    Console.WriteLine("true");
        //}
    }
}

