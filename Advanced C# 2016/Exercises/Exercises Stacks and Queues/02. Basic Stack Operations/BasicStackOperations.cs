using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            const string True = "true";
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int amountToPush = commands[0];
            int amountToPop = commands[1];
            int numToCheck = commands[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (amountToPush > numbers.Length)
            {
                PrintZero();
                return;
            }

            Stack<int> operationStack = new Stack<int>();
            for (int i = 0; i < amountToPush; i++)
            {
                operationStack.Push(numbers[i]);
            }

            if (amountToPop > operationStack.Count)
            {
                PrintZero();
                return;
            }

            for (int i = 0; i < amountToPop; i++)
            {
                operationStack.Pop();
            }

            if (!operationStack.Contains(numToCheck))
            {
                if (operationStack.Count > 0)
                {
                    Console.WriteLine(operationStack.Min());
                }
                else
                {
                    PrintZero();
                }
                
            }
            else
            {
                Console.WriteLine(True);
            }
        }

        private static void PrintZero()
        {
            Console.WriteLine(0);
        }
    }
}
