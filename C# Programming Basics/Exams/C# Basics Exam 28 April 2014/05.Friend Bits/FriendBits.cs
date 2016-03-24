using System;
class FriendBits
{
    static void Main()
    {
        //"Friend bits" are sequences of bits with the same value. All other bits are "alone bits". 
        //For example in the sequence 11101010011011010000111010110001 the friend bits (marked in grey, from left to right) 
        //are: 111, 00, 11, 11, 0000, 111, 11 and 000. In the same sequence alone bits are: 0101, 0, 01, 010 and 1.
        //We are given a 32-bit integer n. Write a program that extracts all friend bits and all alone bits from n. 
        //Append all friend bits in the same order in which they appear in n and print their decimal representation f. 
        //Respectively, append all alone bits in the order in which they appear in n and print their decimal representation a.
        //Input
        //The input data should be read from the console. It holds the number n at the first line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of exactly 2 lines: the numbers f and a.
        //Constraints
        //•	All input and output numbers should be unsigned 32-bit integers in the range [0 to 4 294 967 295].
        //•	Time limit: 0.1 seconds.
        //•	Memory limit: 16 MB.
        //Examples
        //Input     	Output	Explanation
        //3933015729	1896696 3933015729 = 11101010011011010000111010110001(2)
        //              661	    friend bits = 111 00 1111 0000 111 11 000(2) = 1896696
        //                      alone bits = 0101 0 01 010 1(2) = 661
        //3822674602	466840  3822674602 = 11100011110110010110001010101010(2)
        //              2730	friend bits = 1110001111 1100 11000 (2) = 466840
        //                      alone bits = 0 10 1010101010(2) = 2730
        //
        //21	        0       21 = 10101(2)
        //	            21      friend bits = (empty) = 0
        //                      alone bits = 10101(2) = 21
        //
        //15	        15      15 = 1111(2)
        //              0	    friend bits = 1111(2) = 15
        //                      alone bits = (empty) = 0

        uint n = uint.Parse(Console.ReadLine());
        uint friend = 0;
        uint alone = 0;
        for (int i = 31; i >= 0; i--)
        {
            uint num1 = n >> i & 1;
            uint num2 = n >> (i + 1) & 1;
            uint num3 = n >> (i - 1) & 1;
            if (((i != 31) & (num1 == num2)) | ((i != 0) & (num1 == num3)))
            {
                friend = (friend << 1) | num1;
            }
            else
            {
                alone = (alone << 1) | num1;
            }
        }
        Console.WriteLine(friend);
        Console.WriteLine(alone);


        //uint n = uint.Parse(Console.ReadLine());
        //uint friend = 0;
        //uint alone = 0;
        //for (int i = 0; i < 32; i++)
        //{
        //    uint num1 = n >> (31 - i) & 1;
        //    uint num2 = n >> (31 - (i + 1)) & 1;
        //    uint num3 = n >> (31 - (i - 1)) & 1;
        //    if ((i != 0 & num1 == num3) | (i != 31 & num1 == num2))
        //    {
        //        friend <<= 1;
        //        friend |= num1;
        //    }
        //    else
        //    {
        //        alone <<= 1;
        //        alone |= num1;
        //    }
        //}
        //Console.WriteLine(friend);
        //Console.WriteLine(alone);
    }
}

