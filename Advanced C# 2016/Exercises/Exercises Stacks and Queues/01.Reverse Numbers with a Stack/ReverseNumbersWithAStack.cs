using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers_with_a_Stack
{
    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " "); 
            }

            Console.WriteLine();
        }
    }
}
