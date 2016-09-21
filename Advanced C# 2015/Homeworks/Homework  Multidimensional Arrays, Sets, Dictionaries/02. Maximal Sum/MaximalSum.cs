using System;
using System.Collections.Generic;
using System.Linq;
class MaximalSum
{
    static void Main()
    {
        //Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 
        //that has maximal sum of its elements. 
        //On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row 
        //with its columns.
        //Print the elements of the 3 x 3 square as a matrix, along with their sum.
        //Input	            Matrix	        Output
        //4 5               1 5 5 2 4       Sum = 75
        //1 5 5 2 4         2 1 4 14 3      1 4 14
        //2 1 4 14 3        3 7 11 2 8      7 11 2
        //3 7 11 2 8        4 8 12 16 4     8 12 16
        //4 8 12 16 4	 	

        int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = matrixSize[0];
        int m = matrixSize[1];
        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            int[] rows = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rows[j];
            }
        }

        int maxSum = int.MinValue;
        int sum = 0;
        int maxRow = 0;
        int maxCol = 0;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < m - 2; j++)
            {
                sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                    matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                    matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = i;
                    maxCol = j;
                }
            }
        }
        Console.WriteLine();

        Console.WriteLine("Sum = {0}", maxSum);

        Console.WriteLine();

        for (int i = maxRow; i < maxRow + 3; i++)
        {
            for (int j = maxCol; j < maxCol + 3; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}