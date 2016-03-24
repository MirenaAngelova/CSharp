using System;
using System.Collections.Generic;

    class longestAlpha
    {
        static void Main()
        {
            string[] w = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            //filll the matrix 
            string start = w[0];
            int startInt = 1;
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(startInt);
                    startInt++;
                }
                Console.WriteLine();
            }
            
        }
    }

