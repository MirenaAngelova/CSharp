using System;
class BitShooter
{
    static void Main()
    {
//        //We are given a bit field in the form of 64-bit integer number. We shoot it 3 times. Each shoot has a center and 
//        //a size. 
//        //The shoot damages size bits around the shoot center (makes these bits 0). Finally, the bit field is split 
//        //into left side (bits 63 … 32) and right side (bits 31 … 0). Write a program that calculates how many bits survive 
//        //(have value 1) after the shoots in the left side and in the right side of the bit field. The bits are numbered 
//        //as traditionally in programming: from right to left from 0 to 63.
//        //Input
//        //The input data should be read from the console. It will consist of exactly 4 lines:
//        //•	At the first line you will have a 64-bit integer, corresponding to the bit field.
//        //•	At each of the next 3 lines we have 2 numbers: shoot center and shoot size – integers, split by a space.
//        //The input data will always be valid and in the format described. There is no need to check it explicitly.
//        //Output
//        //The output should be printed on the console. It should consists of exactly 2 lines:
//        //•	The first line print "left: …" and the number of alive bits in the left side.
//        //•	The second line print "right: …" and the number of alive bits in the right side.
//        //Constraints
//        //•	The bit field will be a 64-bit integer in the range [0 … 18 446 744 073 709 551 615].
//        //•	The values for the center will be integers will be integers in range [0 … 63].
//        //•	The values for the size will be odd integers in range [1 … 99].
//        //•	Allowed working time for your program: 0.25 seconds.
//        //•	Allowed memory: 16 MB.
//        //Examples
//        //Input	                Output
//        //4227378815862876842   left: 10
//        //1 5                   right: 11
//        //22 3
//        //58 7	
//        //
//        //Comments
//        //4227378815862876842(10) = 0011101010101010101010101010001010101010100001001010101010101010  
//        //                          0011101010101010101010101010001010101010100001001010101010100000  
//        //                          0011101010101010101010101010001010101010000001001010101010100000  
//        //                          0000000000101010101010101010001010101010000001001010101010100000  
//        //                        00000000001010101010101010100010 | 10101010000001001010101010100000  left: 10; right: 11
//        //
//        //Input	                Output
//        //9223372036854775806   left: 15
//        //15 7                  right: 24
//        //43 15
//        //58 1	                     

        ulong integer = ulong.Parse(Console.ReadLine());
        //Console.WriteLine(Convert.ToString((long)integer, 2).PadLeft(64, '0'));
        ulong newInteger = 0;
        for (int i = 0; i < 3; i++)
        {
            string[] shoot = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            int centerShoot = int.Parse(shoot[0]);
            int sizeShoot = int.Parse(shoot[1]);
            int startBit = centerShoot - (sizeShoot / 2);
            int endBit = centerShoot + (sizeShoot / 2);
            for (int bit = startBit; bit <= endBit; bit++)
            {
                if (bit >= 0 & bit < 64)
                {
                    newInteger = newInteger | ((ulong)1 << bit);
                }
            }
        }
        integer = integer & (~newInteger);
        //Console.WriteLine(Convert.ToString((long)integer, 2).PadLeft(64, '0'));
        int rightSide = 0;
        int leftSide = 0;
        ulong countBits = 0;
        int count = 0;
        for (int i = 0; i < 64; i++)
        {
            countBits = (integer >> i) & (ulong)1;
            //Console.WriteLine(countBits);
            count = (int)countBits;
            if (i < 32)
            {
                rightSide += count;
            }
            else
            {
                leftSide += count;
            }
        }
        Console.WriteLine("left: {0}", leftSide);
        Console.WriteLine("right: {0}", rightSide);
    }
}

