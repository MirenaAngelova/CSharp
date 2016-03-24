using System;
class BitBuilder
{
    static int bitCount = 0;
    static void Main()
    {
        //Pesho is a nasty little brat who likes to do mischiefs all the time. You are given the task to keep him busy 
        //and thus have come up with a game you named Bit Builder. The rules of the game are as follows:
        //You are given a sequence of bits (an integer number) and Pesho chooses a position and issues an order 
        //in order to manipulate the given bit. If he says flip, you have to reverse the value of the bit. 
        //For example if the bit’s value is 1, it has to become 0. If Pesho’s order is remove, 
        //you have to remove the bit from the bit sequence (1 1100 1101  0 1110 0101). However, if he issues the order 
        //insert the bit 1 has to be inserted in the wanted position (0 1110 0101  1 1100 1101). 
        //If he issues the order skip, you don’t have to do anything with the given bit.
        //Whenever Pesho says quit, the game ends.
        //Input
        //The input data should be read from the console. On the first line, you are given an integer number and on each 
        //of the next two lines, you have a bit position and an issued order.
        //The possible orders are as follows: “flip”, “remove”, “insert”, “skip”. 
        //On the last input line, you are given the order “quit”, which means that the game has ended.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //On the only output line print the bits of the number after the end of the game 
        //Constraints
        //•	The input number will be a 32-bit integer in the range [0 … 2 147 483 647].
        //•	The position will be in the range [0 … 31].
        //•	The maximum number of commands will be 30.
        //•	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output	Explanation	            Input	Output	Explanation
        //255       638     1111 1111               11230   11243   10 1011 1101 1110 
        //0                  000 1111 1110         9                0101 0111 1101 1110
        //flip               100 1111 1110         insert           101 0111 1101 11107
        //10                 10 0111 1110          15               10 1011 1110 1111
        //insert             10 0111 1110 (638)    remove           10 1011 1110 1011 
        //1                                         0               (11243)
        //remove                                    remove
        //8                                         2
        //skip                                      flip
        //quit	                                    quit	

        long number = long.Parse(Console.ReadLine());
        while (true)
        {
            string input = Console.ReadLine();
            int position;
            CountBits(number);
            //Console.WriteLine(bitCount);
            if (input != "quit")
            {
                position = int.Parse(input);
            }
            else
            {
                break;
            }
            string command = Console.ReadLine();
            switch (command)
            {
                case "flip":
                    number ^= (long)1 << position;
                    break;
                case "remove":
                    number = RemoveBit(position, number);
                    break;
                case "insert":
                    number = InsertBit(position, number);
                    break;
            }
        }
        Console.WriteLine(number);
    }
    private static long RemoveBit(int position, long number)
    {
        long currentNumber = 0;
        bool changeOccured = false;
        for (int i = 0; i < bitCount; i++)
        {
            long currentBit = (number >> i) & 1;
            if (i != position)
            {
                currentNumber >>= 1;
                currentNumber |= currentBit << (bitCount - 1);
            }
            else
            {
                changeOccured = true;
            }
        }
        if (changeOccured)
        {
            currentNumber >>= 1;
        }
        return currentNumber;
    }
    private static long InsertBit(int position, long number)
    {
        long currentNum = 0;
        bool changeOccured = false;
        for (int i = 0; i < bitCount; i++)
        {
            currentNum >>= 1;
            if (i == position)
            {
                currentNum |= (long)1 << bitCount;
                i--;
                position = -1;
                changeOccured = true;
            }
            else
            {
                long currentBit = (number >> i) & 1;
                currentNum |= currentBit << bitCount;
            }
        }
        if (!changeOccured)
        {
            currentNum >>= 1;
            currentNum |= (long)1 << position;
        }
        return currentNum;
    }
    private static void CountBits(long number)
    {
        long numToCount = number;
        bitCount = 0;
        while (numToCount > 0)
        {
            bitCount++;
            numToCount >>= 1;
        }
    }
}

