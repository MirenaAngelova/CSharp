using System;
using System.Linq;
class MatrixOfPalindromes
{
    static void Main()
    {
        //Write a program to generate the following matrix of palindromes of 3 letters with r rows and c columns:
        //Input	Output
        //3 6	aaa aba aca	ada aea afa
        //      bbb bcb bdb	beb bfb bgb
        //      ccc cec cdc	cfc cgc chc
        //2 3	aaa aba aca
        //      bbb bcb bdb
        //1 1	aaa
        //1 3	aaa aba aca

        string input = Console.ReadLine();
        int[] rowsCols = input.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        char letter = 'a';
        for (int i = 0; i < rowsCols[0]; i++)
        {
            for (int j = 0, k = letter; j < rowsCols[1]; j++, k++)
            {
                Console.Write("{0}{1}{0} ", letter, (char)k);
            }
            Console.WriteLine();
            letter++;
        }
    }
}

