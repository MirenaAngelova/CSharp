using System;

class LongSequence
{
    static void Main()
    {
        //Write a program that prints the first 1000 members
        //of the sequence: 2, -3, 4, -5, 6, -7, … You might need to learn
        //how to use loops in C# (search in Internet).

        int count = 0;
        for (int i = 2; i < 1002; i++)
        {
            if (count % 9 == 0)
            {
                Console.WriteLine();
            }

            count++;
            if (i % 2 == 0)
            {
                Console.Write("{0}, ", i);
            }
            else
            {
                Console.Write("{0}, ", -i);
            }
           
        }
        
        Console.WriteLine();
    }
}

