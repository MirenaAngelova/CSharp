using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Rubik_s_Matrix
{
    class RubicsMatrix
    {
        static void Main()
        {
            string[] rowsCols = Console.ReadLine().Split();
            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);

            int[,] matrixOrder = new int[rows, cols];
            int n = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrixOrder[i, j] = n;
                    n++;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ExecuteCommand(matrixOrder, rows, cols, inputLine);
            }

            PrintMatrix(matrixOrder, rows, cols);
            RearrangeMatrix(matrixOrder, rows, cols);

        }

        private static void RearrangeMatrix(int[,] matrixOrder, int rows, int cols)
        {
            int index = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrixOrder[i, j] == index)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int m = 0; m < rows; m++)
                        {
                            for (int n = 0; n < cols; n++)
                            {
                                if (matrixOrder[m, n] == index)
                                {
                                    Console.WriteLine($"Swap ({i}, {j}) with ({m}, {n})");
                                    int previousElem = matrixOrder[i, j];
                                    matrixOrder[i, j] = matrixOrder[m, n];
                                    matrixOrder[m, n] = previousElem;
                                    break;
                                }
                            }
                        }
                    }

                    index++;
                }
            }
        }

        private static void PrintMatrix(int[,] matrixOrder, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrixOrder[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void ExecuteCommand(int[,] matrixOrder, int rows, int cols, string[] inputLine)
        {
            int rowCol = int.Parse(inputLine[0]);
            string direction = inputLine[1];
            int moves = int.Parse(inputLine[2]);
            switch (direction)
            {
                case "up":
                    MoveUp(matrixOrder, rows, rowCol, moves);
                    break;
                case "down":
                    MoveDown(matrixOrder, rows, rowCol, moves);
                    break;
                case "left":
                    MoveLeft(matrixOrder, cols, rowCol, moves);
                    break;
                case "right":
                    MoveRight(matrixOrder, cols, rowCol, moves);
                    break;
            }

        }

        private static void MoveDown(int[,] matrixOrder, int rows, int rowCol,int moves)
        {
            for (int m = 0; m < moves % rows; m++)
            {
                int lastElement = matrixOrder[rows - 1, rowCol];
                int i = rows - 1;
                while (i > 0)
                {
                    matrixOrder[i, rowCol] = matrixOrder[i - 1, rowCol];
                    i--;
                }
                matrixOrder[0, rowCol] = lastElement;
            }
        }

        private static void MoveUp(int[,] matrixOrder, int rows, int rowCol, int moves)
        {
         
            for (int m = 0; m < moves % rows; m++)
            {
                int firstElement = matrixOrder[0, rowCol];
                int i = 0;
                while (i < rows - 1)
                {
                    matrixOrder[i, rowCol] = matrixOrder[i + 1, rowCol];
                    i++;
                }

                matrixOrder[rows - 1, rowCol] = firstElement;
            }
        }

        private static void MoveLeft(int[,] matrixOrder, int cols, int rowCol, int moves)
        {

            for (int m = 0; m < moves % cols; m++)
            {
                int firstElement = matrixOrder[rowCol, 0];
                int j = 0;
                while (j < cols - 1)
                {
                    matrixOrder[rowCol, j] = matrixOrder[rowCol, j + 1];
                    j++;
                }

                matrixOrder[rowCol, cols - 1] = firstElement;
            }
        }

        private static void MoveRight(int[,] matrixOrder, int cols, int rowCol, int moves)
        {
            for (int m = 0; m < moves % cols; m++)
            {
                int lastElement = matrixOrder[rowCol, cols - 1];
                int j = cols - 1;
                while (j > 0)
                {
                    matrixOrder[rowCol, j] = matrixOrder[rowCol, j - 1];
                    j--;
                }
                matrixOrder[rowCol, 0] = lastElement;
            }
        }
    }
}
