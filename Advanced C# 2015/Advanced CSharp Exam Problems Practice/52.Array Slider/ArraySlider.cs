using System;
using System.Linq;
using System.Numerics;
class ArraySlider
{
    static void Main()
    {
        BigInteger[] array = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse).ToArray();

        string command = Console.ReadLine();

        int currentIndex = 0;

        while (command != "stop")
        {
            string[] commands = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int offset = int.Parse(commands[0]) % array.Length;

            char operation = char.Parse(commands[1]);

            int operand = int.Parse(commands[2]);

            if (offset < 0)
            {
                offset += array.Length;
            }

            currentIndex = (currentIndex + offset) % array.Length;

            PerformOperation(array, currentIndex, operation, operand);

            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", array));
    }
    private static void PerformOperation(BigInteger[] array, int currentIndex, char operation, int operand)
    {
        switch(operation)
        {
            case '&':
                array[currentIndex] &= operand;
                break;
            case '|':
                array[currentIndex] |= operand;
                break;
            case '^':
                array[currentIndex] ^= operand;
                break;
            case '+':
                array[currentIndex] += operand;
                break;
            case '-':
                array[currentIndex] -= operand;
                if (array[currentIndex] < 0)
                {
                    array[currentIndex] = 0;
                }
                break;
            case '*':
                array[currentIndex] *= operand;
                break;
            case '/':
                array[currentIndex] /= operand;
                break;
        }
    }
}