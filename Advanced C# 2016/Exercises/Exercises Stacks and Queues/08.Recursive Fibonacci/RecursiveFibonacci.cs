using System;
using System.Numerics;

namespace _08.Recursive_Fibonacci
{
    public class RecursiveFibonacci
    {
        private const int MaxNumberCount = 50;
        private static BigInteger[] fibonacci = new BigInteger[MaxNumberCount];

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = CalcRecursiveFibonacci(n);
            Console.WriteLine(result);
        }

        private static BigInteger CalcRecursiveFibonacci(int n)
        {
            if (fibonacci[n] == 0)
            {
                if (n == 1 || n == 2)
                {
                    fibonacci[n] = 1;
                }
                else
                {
                    fibonacci[n] = CalcRecursiveFibonacci(n- 1) + CalcRecursiveFibonacci(n - 2);
                }
            }

            return fibonacci[n];
        }
    }
}
