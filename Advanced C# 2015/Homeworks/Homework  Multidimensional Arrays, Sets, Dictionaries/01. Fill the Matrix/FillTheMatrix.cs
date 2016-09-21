using System;
class FillTheMatrix
{
    static void Main()
    {
        //Write two programs that fill and print a matrix of size N x N. Filling a matrix in the regular pattern 
        //(top to bottom and left to right) is boring. Fill the matrix as described in both patterns below:
        //Pattern A	            Pattern B
        //1 5 9  13             1 8 9  16
        //2 6 10 14             2 7 10 15
        //3 7 11 15             3 6 11 14
        //4 8 12 16             4 5 12 13

        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        FillPatternA(matrix);
        PrintMatrix(matrix);

        Console.WriteLine();

        FillPatternB(matrix);
        PrintMatrix(matrix);
    }
    static void FillPatternA(int[,] matrix)
    {
        int element = 1;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, j] = element;
                element++;
            }
        }
    }


    static void FillPatternB(int[,] matrix)
    {
        int element = 1;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j % 2 == 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = element;
                    element++;
                }
            }
            else
            {
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    matrix[i, j] = element;
                    element++;
                }
            }
        }
    }

    //static void FillPatternB(int[,] matrix)
    //{
    //    int element = 1;
    //    int i = 0;
    //    int iChange = 1;

    //    for (int j = 0; j < matrix.GetLength(1); j++)
    //    {
    //        do
    //        {
    //            matrix[i, j] = element;
    //            element++;
    //            i += iChange;
    //        } while (i >= 0 && i < matrix.GetLength(0));

    //        i -= iChange;
    //        iChange = -iChange;
    //    }
    //}
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, 3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}