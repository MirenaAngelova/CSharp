using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.Rubik_s_Matrix_2
{
    public class RubiksMatrix2
    {
        private static Dictionary<Matrix, int> rubiksDictionary;
        private static int[,] rubiksMatrix;
        private static int[,] updateRubiksMatrix;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            ProcessInput();
            CreateDictionary();
            ProcessOutput();
        }

        private static void ProcessOutput()
        {
            
            for (int matrixElement = 1; matrixElement <= rows * cols; matrixElement++)
            {
                int col = (matrixElement - 1)%cols;
                int row = (matrixElement - 1 - col)/rows;
                Matrix matrix = new Matrix(row, col);
                var currentElement = rubiksDictionary
                    .FirstOrDefault(cE => cE.Key.Row == matrix.Row && cE.Key.Col == matrix.Col);
                if (currentElement.Value == matrixElement)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    var element = rubiksDictionary.FirstOrDefault(e => e.Value == matrixElement);
                    int temp = currentElement.Value;

                    rubiksDictionary[currentElement.Key] = element.Value;
                    rubiksDictionary[element.Key] = temp;

                    Console.WriteLine($"Swap ({row}, {col})" +
                                      $" with ({element.Key.Row}, {element.Key.Col})");
                }
            }
        }

        private static void CreateDictionary()
        {
            rubiksDictionary = new Dictionary<Matrix, int>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int value = updateRubiksMatrix[row, col];
                    Matrix matrix = new Matrix(row, col);
                    rubiksDictionary.Add(matrix, value);
                }
            }
        }

        private static void ProcessInput()
        {
            string[] rowsCols = Console.ReadLine().Split();
            rows = int.Parse(rowsCols[0]);
            cols = int.Parse(rowsCols[1]);

            rubiksMatrix = new int[rows, cols];
            updateRubiksMatrix = new int[rows, cols];
            FillMatrices();

            int n = int.Parse(Console.ReadLine());
            ExecuteCommands(n);
        }

        private static void ExecuteCommands(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                int rowCol = int.Parse(commands[0]);
                string command = commands[1];
                int moves = int.Parse(commands[2]);

                switch (command)
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

                rubiksMatrix = (int[,])updateRubiksMatrix.Clone();
            }
        }

        private static void ShufflingMatrixCols(int col, int rows, int moves)
        {
            for (int row = 0; row < rows; row++)
            {
                int updateRow = (rows + moves % rows + row) % rows;
                updateRubiksMatrix[row, col] = rubiksMatrix[updateRow, col];
            }
        }

        private static void ShufflingMatrixRows(int row, int cols, int moves)
        {
            for (int col = 0; col < cols; col++)
            {
                int updateCol = (cols + moves % cols + col) % cols;
                updateRubiksMatrix[row, col] = rubiksMatrix[row, updateCol];
            }
        }

        private static void FillMatrices()
        {
            for (int row = 0; row < rubiksMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rubiksMatrix.GetLength(1); col++)
                {
                    rubiksMatrix[row, col] = row * rubiksMatrix.GetLength(1) + col + 1;
                    updateRubiksMatrix[row, col] = row * updateRubiksMatrix.GetLength(1) + col + 1;
                }
            }
        }
    }

    public class Matrix
    {
        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col { get; set; }

        public int Row { get; set; }

        public override string ToString()
        {
            return $"[{this.Row},{this.Col}]";
        }
    }
}
