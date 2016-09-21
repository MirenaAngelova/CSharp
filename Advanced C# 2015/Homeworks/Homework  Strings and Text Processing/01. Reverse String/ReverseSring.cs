using System;
using System.Linq;
class ReverseString
{
    static void Main()
    {
        //Write a program that reads a string from the console, reverses it and prints the result back at the console.
        //Input	     Output
        //sample	 elpmas
        //24tvcoi92	 29iocvt42

        string input = Console.ReadLine();

        //Console.WriteLine(string.Concat(input.Reverse()));

        Console.WriteLine(string.Join("", input.Reverse()));
    }
}