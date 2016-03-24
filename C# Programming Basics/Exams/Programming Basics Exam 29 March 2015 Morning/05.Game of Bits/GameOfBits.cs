using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Game_of_Bits
{
    class GameOfBits
    {
        static void Main(string[] args)
        {
            uint num = uint.Parse(Console.ReadLine());
            uint newNum = num;

            string command = Console.ReadLine();
            while (command != "Game Over!")
            {
                if (command == "Even")
                {
                    num >>= 1;
                }
                newNum = ExtractBits(newNum, num);
                num = newNum;
                command = Console.ReadLine();
            }

            int count = 0;
            while (newNum > 0)
            {
                uint bit = newNum & 1;
                if (bit == 1)
                {
                    count++;
                }
                newNum >>= 1;
            }

            Console.WriteLine("{0} -> {1}", num, count);
        }

        private static uint ExtractBits(uint newNum, uint num)
        {
            newNum = num & 1;
            num >>= 2;
            int count = 1;
            while (num != 0)
            {
                newNum |= (num & 1) << count;
                num >>= 2;
                count++;
            }
            return newNum;
        }
    }
}
