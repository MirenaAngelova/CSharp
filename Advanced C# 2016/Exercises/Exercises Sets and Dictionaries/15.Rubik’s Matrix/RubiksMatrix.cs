using System;

namespace _15.Rubik_s_Matrix
{
    public class RubiksMatrix
    {
        private static int[,] matrix;
        private static int[,] updateMatrix;

        public static void Main()
        {
            string[] rowsCols = Console.ReadLine().Split();

            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);

            matrix = new int[rows, cols];
            updateMatrix = new int[rows, cols];
            FillMatrices();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                ExecuteCommand(rows, cols);
            }

            ProcessOutput(rows, cols);
        }

        private static void ProcessOutput(int rows, int cols)
        {
            for (int matrixElement = 1; matrixElement <= rows * cols; matrixElement++)
            {
                int col = (matrixElement - 1) % cols;
                int row = (matrixElement - 1 - col) / cols;
                if (updateMatrix[row, col] == matrixElement)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    int index = matrixElement + 1;
                    CheckEquality(row, col, matrixElement, index, rows, cols);
                }
            }
        }

        private static void CheckEquality(
            int row, int col, int matrixElement,
            int index, int rows, int cols)
        {
            while (index <= rows * cols)
            {
                int indexCol = (index - 1) % cols;
                int indexRow = (index - 1 - indexCol) / cols;
                if (updateMatrix[indexRow, indexCol] == matrixElement)
                {

                    Swap(ref updateMatrix[row, col], ref updateMatrix[indexRow, indexCol]);
                    Console.WriteLine($"Swap ({row}, {col}) with ({indexRow}, {indexCol})");
                    break;
                }
                else
                {
                    index++;
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void ExecuteCommand(int rows, int cols)
        {
            string[] input = Console.ReadLine().Split();

            int rowCol = int.Parse(input[0]);
            string direction = input[1];
            int moves = int.Parse(input[2]);
            switch (direction)
            {
                case "right":
                    ShufflingMatrixRows(rowCol, cols, -moves);
                    break;
                case "down":
                    ShufflingMatrixCols(rowCol, rows, -moves);
                    break;
                case "left":
                    ShufflingMatrixRows(rowCol, cols, moves);
                    break;
                case "up":
                    ShufflingMatrixCols(rowCol, rows, moves);
                    break;
            }

            matrix = (int[,])updateMatrix.Clone();
        }

        private static void ShufflingMatrixCols(int col, int rows, int moves)
        {
            for (int row = 0; row < rows; row++)
            {
                int updateRow = (rows + moves % rows + row) % rows;
                updateMatrix[row, col] = matrix[updateRow, col];
            }
        }

        private static void ShufflingMatrixRows(int row, int cols, int moves)
        {
            for (int col = 0; col < cols; col++)
            {
                int updateCol = (cols + moves % cols + col) % cols;
                updateMatrix[row, col] = matrix[row, updateCol];
            }
        }

        private static void FillMatrices()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = row * matrix.GetLength(1) + col + 1;
                    updateMatrix[row, col] = row * matrix.GetLength(1) + col + 1;
                }
            }
        }
    }
}
