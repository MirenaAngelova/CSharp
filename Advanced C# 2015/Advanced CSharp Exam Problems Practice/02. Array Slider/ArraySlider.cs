using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Array_Slider
{
    class ArraySlider
    {
        static void Main()
        {
            BigInteger numberToOperate;
            long currentIndex = 0;
            long previousIndex = 0;

            BigInteger[] intArray = Console.ReadLine()
                .Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse).ToArray();
                
            string inputLine = Console.ReadLine();
            while (inputLine != "stop")
            {
                string[] commands = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                long offset = long.Parse(commands[0]);
                char operation = char.Parse(commands[1]);
                long operand = long.Parse(commands[2]);

                int length = intArray.Length;
                currentIndex = FindIndex(length, offset, currentIndex, previousIndex);
                previousIndex = currentIndex;
                numberToOperate = intArray[currentIndex];
                numberToOperate = ExecuteOperation(numberToOperate, operation, operand);
                intArray[currentIndex] = numberToOperate;

                inputLine = Console.ReadLine();
            }

            PrintArray(intArray);
        }

        private static void PrintArray(BigInteger[] intArray)
        {
            Console.WriteLine("[" + string.Join(", ", intArray) + "]");
        }

        private static long FindIndex(
            long length,
            long offset,
            long currentIndex,
            long previousIndex)
        {
            long sumIndex = previousIndex + offset;
            if (sumIndex < 0)
            {
                currentIndex = (length + (offset % length) + previousIndex)%length;
            }
            else
            {
                currentIndex = (previousIndex + offset) % length;
            }
            
            return currentIndex;
        }

        private static BigInteger ExecuteOperation(BigInteger numberToOperate, char operation, long operand)
        {
            switch (operation)
            {
                case '&':
                    numberToOperate &= operand;
                    break;
                case '|':
                    numberToOperate |= operand;
                    break;
                case '^':
                    numberToOperate ^= operand;
                    break;
                case '+':
                    numberToOperate += operand;
                    break;
                case '-':
                    numberToOperate -= operand;
                    if (numberToOperate < 0)
                    {
                        numberToOperate = 0;
                    }
                    //numberToOperate = numberToOperate < 0 ? 0 : numberToOperate;
                    break;
                case '*':
                    numberToOperate *= operand;
                    break;
                case '/':
                    numberToOperate /= operand;
                    break;
            }

            return numberToOperate;
        }
    }
}
