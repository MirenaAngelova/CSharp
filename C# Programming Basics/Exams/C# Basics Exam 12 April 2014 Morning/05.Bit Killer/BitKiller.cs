using System;
class BitKiller
{
    static void Main()
    {
        //You are given a sequence of bytes. Consider each byte as sequence of exactly 8 bits.  You are given also
        //a number step. Write a program to remove (kill) all the bits at positions: 3, 3 + step, 3 + 2*step, ... 
        //Print the output as a sequence of bytes. In case the last byte have less than 8 bits, add trailing zeroes 
        //at its right end. Bits in each byte are counted from the leftmost to the rightmost. Bits are numbered starting from 0.
        //Input
        //•	The input data should be read from the console.
        //•	The number n stays at the first line.
        //•	The number step stays at the second line.
        //•	At each of the next n lines n bytes are given, each at a separate line. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. Print the output bytes, each at a separate line.
        //Constraints
        //•	The number n will be an integer number in the range [1…100].
        //•	The number step will be an integer number in the range [1…20].
        //•	The n numbers will be integers in the range [0…255].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	  Output	Comments
        //2       90    	We have the following input sequence of 16 bits (2 bytes):
        //11      188       01101101 01010111. We kill the bits 1 and 12 (step=11).
        //109               Obtained sequence: 01011010 101111.
        //87                Padding: 2 zeroes at the end. Result: 01011010 10111100.
        //
        //Input	  Output	Comments
        //3       97        We have the following input sequence of 24 bits (3 bytes):
        //2       240       00101101 01010111 11111010. We kill bits 1, 3, …, 23 (step=2).
        //45                Obtain the sequence: 01100001 1111. 
        //87                We pad it with 4 zeroes at the end to obtain 2 full bytes.
        //250	            Result: 01100001 11110000.
        //	
        //Input	  Output	Comments
        //2       97        We have the following input sequence of 16 bits (2 bytes):
        //2                 00101101 01010111. We kill bits 1, 3, 5, …, 15 (step=2).
        //45                Obtained sequence: 01100001 (8 bits).
        //87	            No padding is needed. Result: 01100001.	

        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int newNumbers = 0;
        int count = 0;
        int counter = 0;
        for (int i = 0; i < n; i++)
        {
            int numbers = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                if (!(((step == 1) & (count > 0)) | (count % step == 1)))
                {
                    int number = numbers >> (7 - j) & 1;
                    newNumbers = newNumbers << 1;
                    newNumbers = newNumbers | number;
                    counter++;
                }
                if (counter == 8)
                {
                    Console.WriteLine(newNumbers);
                    newNumbers = 0;
                    counter = 0;
                }
                count++;
            }
        }
        if (counter > 0)
        {
            newNumbers = newNumbers << (8 - counter);
            Console.WriteLine(newNumbers);
        }
    }
}




