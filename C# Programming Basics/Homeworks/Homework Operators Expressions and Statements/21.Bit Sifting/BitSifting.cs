using System;
class BitSifting
{
    static void Main()
    {
        //In this problem we'll be sifting bits through sieves (sift = пресявам, sieve = сито).
        //You will be given an integer, representing the bits to sieve, and several more numbers, 
        //representing the sieves the bits will fall through. Your task is to follow the bits as they fall down, 
        //and determine what comes out of the other end.
        //Example
        //For this example, imagine we are working with 8-bit integers (the actual problem uses 64-bit ones). 
        //Let the initial bits be given as 165 (10100101 in binary), and the sieves be 138 (10001010), 
        //84 (01010100) and 154 (10011010). The 1 bits from the initial number fall through the 0 bits of the sieves 
        //and stop if they reach a 1 bit; if they make it to the end, they become a part of the final number.
        //In this case, the final number is 33 (00100001), which has two 1 bits in its binary form – the answer is 2.	
        //10100101
        //↓ ↓  ↓ ↓
        //10001010
        //  ↓  ↓ ↓
        //01010100
        //  ↓    ↓
        //10011010
        //  ↓    ↓
        //00100001
        //Input
        //The input data should be read from the console.
        //•	On the first line of input, you will read an integer representing the bits to sieve.
        //•	On the second line of input, you will read an integer N representing the number of sieves.
        //•	On the next N lines of input, you will read N integers representing the sieves.
        //The input data will always be valid and in the format described. There is no need to check it.
        //Output
        //The output must be printed on the console.
        //On the single line of the output you must print the count of "1" bits in the final result.
        //Constraints
        //•	All numbers in the input will be between 0 and 18,446,744,073,709,551,615.
        //•	The count of sieves N is in range [0…100].
        //•	Allowed work time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	                 Output	   Input	           Output	Input	             Output
        //584938644408189469     4         918045605434484408  35       5019588773529942006  17
        //3                                0		                    1
        //1817781288526917737                                           5295337384025297044
        //8601652436058397548
        //51827709899390606			

        ulong integer = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = 0; i < n; i++)
        {
            ulong sieves = ulong.Parse(Console.ReadLine());
            for (int j = 0; j <= 63; j++)
            {
                ulong newSieves = (sieves >> j) & 1;
                if (newSieves == 1)
                {
                    integer = integer & ~((ulong)1 << j);
                }
            }
        }
        for (int i = 0; i <= 63; i++)
        {
            ulong siftedInt = (integer >> i) & 1;
            if (siftedInt == 1)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}

