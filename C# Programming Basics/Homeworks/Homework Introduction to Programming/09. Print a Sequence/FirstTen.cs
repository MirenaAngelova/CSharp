using System;
class FirstTen
{
    static void Main()
    {
        //Write a program that prints the first 10 members of the sequence: 
        //2, -3, 4, -5, 6, -7, ...
        for (int i = 2; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("{0}, ", i);
                //"WriteLine" writes a line, including line terminator (return/new line),
                //"Write" does not.
            }
            else
            {
                Console.Write("{0}, ", -i);
            }
        }
        Console.WriteLine();
        //Prints "Press any key to continue . . ." at a separate line.
    }
}