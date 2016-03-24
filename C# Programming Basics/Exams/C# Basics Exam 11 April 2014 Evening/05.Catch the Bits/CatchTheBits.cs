using System;
class CatchTheBits
{
    static void Main()
    {
        //You are given a sequence of bytes. Consider each byte as sequence of exactly 8 bits.  You are given also
        //a number step. Write a program to extract all the bits at positions: 1, 1 + step, 1 + 2*step, ... 
        //Print the output as a sequence of bytes. In case the last byte have less than 8 bits, add trailing zeroes 
        //at its right end. Bits in each byte are counted from the leftmost to the rightmost. Bits are numbered 
        //starting from 0.
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
        //Input	Output	Comments
        //2     128	    We have the following input sequence of 16 bits (2 bytes):
        //11            01101101 01010111.
        //109           We take the bits 1 and 12 (step=11). We obtain the sequence 10.
        //87	        We pad the sequence with 6 trailing zeroes. Result: 10000000.
        //
        //Input	Output	Comments
        //3     63      We have the following input sequence of 24 bits (3 bytes):
        //2     192	    00101101 01010111 11111010
        //45            We take bits 1, 3, 5, …, 23 (step=2). We obtain the sequence:
        //87            00111111 1100. We pad it with 4 zeroes to obtain 2 full bytes.
        //250	        Result: 00111111 11000000.
        //
        //Input	Output	Comments
        //2     63	    We have the following input sequence of 16 bits (2 bytes):
        //2             00101101 01010111
        //45            We take bits 1, 3, 5, …, 15 (step=2). We obtain the sequence:
        //87            00111111 (8 bits). No padding is needed. Result: 00111111.	

        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int countJ = 0;
        int countStep = 0;
        int newNum = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                if (((step == 1) & (countJ > 0)) | (countJ % step == 1))
                {
                    int number = (num >> (7 - j)) & 1;
                    newNum = newNum << 1;
                    newNum = newNum | number;
                    countStep++;
                }
                
                if (countStep == 8)
                {
                    Console.WriteLine(newNum);
                    newNum = 0;
                    countStep = 0;
                }
                countJ++;
            }
        }
        if (countStep > 0)
        {
            newNum = newNum << (8 - countStep);
            Console.WriteLine(newNum);
        }
    }
}

