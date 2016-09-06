using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_Element
{
    public class MaximumElement
    {
        private const int PushElement = 1;
        private const int DeleteElement = 2;
        private const int PrintMaxElement = 3;

        private static Stack<int> queryStack = new Stack<int>(); 
        private static Stack<int> queryMaxStack = new Stack<int>(); 

        private static int[] commands;
        private static int maxElement = int.MinValue;
                       
        public static void Main()
        {
            int countOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCommands; i++)
            {
                commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                ExecuteCommands();
            }
        }

        private static void ExecuteCommands()
        {
            int command = (int)commands[0];
            switch (command)
            {
                case PushElement:
                    int elementToPush = commands[1];
                    queryStack.Push(elementToPush);

                    if (elementToPush >= maxElement)
                    {
                        maxElement = elementToPush;
                        queryMaxStack.Push(maxElement);
                    }
                    break;

                case DeleteElement:
                    int popElement = queryStack.Pop();
                    int currentMax = queryMaxStack.Peek();
                    if (currentMax == popElement)
                    {
                        queryMaxStack.Pop();
                        maxElement = queryMaxStack.Count > 0 ? queryMaxStack.Peek() : int.MinValue;
                    }

                    break;
                case PrintMaxElement:
                    Print(queryMaxStack.Peek());
                    break;
            }
        }

        private static void Print(int maxElement)
        {
            Console.WriteLine(maxElement);
        }
    }
}
