using System;
using System.Collections.Generic;
class RandomizeTheNumbersFromOneToN
{
    static void Main()
    {
        //Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order. Examples:
        //n	    randomized numbers 1…n
        //3	    2 1 3
        //10	3 4 8 2 6 7 9 1 10 5 
       // Note that the above output is just an example. Due to randomness, your program most probably 
        //will produce different results. You might need to use arrays.

        int n = int.Parse(Console.ReadLine());
        int[] num = new int[n];
        int count = 0;
        Random randomN = new Random();
        for (int i = 1; i <= n; i++)
        {
            num[count] = i;
            count++;
        }
        for (int i = 0; i < count; i++)
        {
            int first = randomN.Next(0, count);
            int second = randomN.Next(0, count);
            int third = num[first];
            num[first] = num[second];
            num[second] = third;
        }
        for (int i = 0; i < count; i++)
        {
            Console.Write(num[i] + " ");
        }
        Console.WriteLine();
    }
}
    


