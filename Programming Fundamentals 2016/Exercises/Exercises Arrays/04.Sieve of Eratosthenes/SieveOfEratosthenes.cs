using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    public class SieveOfEratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool[] isPrime = new bool[n + 1];

            Initialize(isPrime);
            MarkNotPrimeNumbers(isPrime);
            PrintPrimeNumbers(isPrime);
        }

        private static void PrintPrimeNumbers(bool[] isPrime)
        {
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }

        private static void MarkNotPrimeNumbers(bool[] isPrime)
        {
            for (int step = 2; step < isPrime.Length; step++)
            {
                for (int i = step * 2; i < isPrime.Length; i += step)
                {
                    isPrime[i] = false;
                }
            }
        }

        private static void Initialize(bool[] isPrime)
        {
            for (int i = 2; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }
        }
    }
}
