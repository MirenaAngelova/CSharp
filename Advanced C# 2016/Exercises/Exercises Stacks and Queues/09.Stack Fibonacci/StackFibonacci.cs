using System;
using System.Collections.Generic;
using System.Numerics;

namespace _09.Stack_Fibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            Stack<BigInteger> fibonacci = new Stack<BigInteger>();
            int n = int.Parse(Console.ReadLine());

            fibonacci.Push(1);
            fibonacci.Push(1);
            int count = 2;
            while (count < n)
            {
                BigInteger fibonacciSecond = fibonacci.Pop();
                BigInteger fibonacciFirst = fibonacci.Peek();

                fibonacci.Push(fibonacciSecond);
                fibonacci.Push(fibonacciFirst + fibonacciSecond);

                count++;
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
