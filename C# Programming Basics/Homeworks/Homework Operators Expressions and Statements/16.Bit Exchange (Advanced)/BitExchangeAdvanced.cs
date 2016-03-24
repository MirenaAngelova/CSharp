using System;
class BitExchangeAdvanced
{
    static void Main()
    {
        //Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} 
        //of a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap. Examples:
        //n	            p	q	k	binary representation of n	            binary result	                        result
        //1140867093	3	24	3	01000100 00000000 01000000 00010101     01000010 00000000 01000000 00100101	    1107312677
        //4294901775	24	3	3	11111111 11111111 00000000 00001111     11111001 11111111 00000000 00111111	    4194238527
        //2369124121	2	22	10	10001101 00110101 11110111 00011001     01110001 10110101 11111000 11010001	    1907751121
        //987654321	    2	8	11	                 -	                                     -	                   overlapping
        //123456789	    26	0	7	                 -	                                     -	                  out of range
        //33333333333	-1	0	33	                 -	                                     -	                  out of range

        uint integerNum = uint.Parse(Console.ReadLine());
        int pBit = int.Parse(Console.ReadLine());
        int qBit = int.Parse(Console.ReadLine());
        int kPositions = int.Parse(Console.ReadLine());

        if ((pBit < 0) | (pBit > 32) | (qBit < 0) | (qBit > 32) | (kPositions > 32 - Math.Max(pBit, qBit)))
        {
            Console.WriteLine("out of range"); //33333333333 is too big for uint
            return;
        }

        if (kPositions > Math.Abs(pBit - qBit))
        {
            Console.WriteLine("overlapping");
            return;
        }

        for (int i = pBit; i <= pBit + kPositions - 1; i++)
        {
            uint ipBit = (uint)(integerNum >> i) & 1;
            uint jqBit =(uint)(integerNum >> qBit - pBit + i) & 1;
            integerNum =(uint)(integerNum & ~(1 << qBit - pBit + i)) | (ipBit << qBit - pBit + i);
            integerNum = (uint)(integerNum & ~(1 << i)) | (jqBit << i);
        }
        Console.WriteLine(integerNum);
    }
}

