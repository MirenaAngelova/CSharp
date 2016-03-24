using System;

class ExchangeVariable
{
    static void Main()
    {
        //Declare two integer variables a and b and assign them with 5 and 10 
        //and after that exchange their values by using some programming logic. 
        //Print the variable values before and after the exchange.
        //Expected Output
        //Before:
        //a = 5
        //b = 10
        //After:
        //a = 10
        //b = 5

        //int a = 5;
        //int b = 10;
        //Console.WriteLine("a = {0}" + "\nb = {1}", a, b);
        //int c = a;
        //a = b;
        //b = c;
        //Console.WriteLine("a = {0}" + "\nb = {1}", a, b);

        int a = 5;
        int b = 10;
        Console.WriteLine("a = {0}" + "\nb = {1}", a, b);
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("a = {0}" + "\nb = {1}", a, b);
    }
}

