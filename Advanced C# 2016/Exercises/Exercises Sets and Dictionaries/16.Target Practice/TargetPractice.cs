using System;

namespace _16.Target_Practice
{
    public class TargetPractice
    {
        public static void Main()
        {
            const int BoundsCount = 4;

            string[] rowsCols = Console.ReadLine().Split();
            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);

            char[,] targetPractice = new char[rows, cols];

            string snake = Console.ReadLine();
            FillMatrix(targetPractice, snake, rows, cols);

            string[] commands = Console.ReadLine().Split();
            int[] rowColBounds = new int[BoundsCount];
            rowColBounds = BlastedSnake(targetPractice, commands, rows, cols);
            FallingDownSnakeRemains(targetPractice,rowColBounds);
            PrintMatrix(targetPractice, rows, cols);
        }

        private static void FallingDownSnakeRemains(
            char[,] targetPractice, int[] rowColBounds)
        {
            int lowerBoundRow = rowColBounds[0];
            int upperBoundRow = rowColBounds[1];
            int lowerBoundCol = rowColBounds[2];
            int upperBoundCol = rowColBounds[3];

            for (int row = upperBoundRow - 1; row >= 0 ; row--)
            {
                for (int col = upperBoundCol; col >= lowerBoundCol ; col--)
                {
                    if (targetPractice[row, col] != ' ')
                    {
                        int reserve = row;
                        char reserveElement = targetPractice[row, col];
                        while (row < upperBoundRow && targetPractice[row + 1, col] == ' ')
                        {
                            targetPractice[row + 1, col] = reserveElement;
                            targetPractice[row, col] = ' ';
                            row++;
                        }

                        row = reserve;
                    }
                }
            }
        }

        private static int[] BlastedSnake(char[,] targetPractice, string[] commands, int rows, int cols)
        {
            int impactRow = int.Parse(commands[0]);
            int impactCol = int.Parse(commands[1]);
            int radius = int.Parse(commands[2]);

            int lowerBoundRow = Math.Max(0, impactRow - radius);
            int upperBoundRow = Math.Min(rows - 1, impactRow + radius);
            int lowerBoundCol = Math.Max(0, impactCol - radius);
            int upperBoundCol = Math.Min(cols - 1, impactCol + radius);
            int[] rowColBounds = new int[] {lowerBoundRow, upperBoundRow, lowerBoundCol, upperBoundCol};

            targetPractice[impactRow, impactCol] = ' ';

            for (int row = lowerBoundRow; row <= upperBoundRow; row++)
            {
                for (int col = lowerBoundCol; col <= upperBoundCol; col++)
                {
                    double distance = Math.Sqrt(
                        (row - impactRow)*(row - impactRow) + (col - impactCol)*(col - impactCol));
                    if (distance <= radius && 
                        targetPractice[row, col] != targetPractice[impactRow, impactCol])
                    {
                        targetPractice[row, col] = ' ';
                    }
                }
            }

            return rowColBounds;
        }

        private static void PrintMatrix(char[,] targetPractice, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(targetPractice[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] targetPractice, string snake, int rows, int cols)
        {
            bool isMoveLeft = true;
            int index = 0;
            int len = snake.Length;
            for (int row = rows - 1; row >= 0; row--)
            {
                int updateCol = isMoveLeft ? -1 : 1;
                int col = updateCol == -1 ? cols - 1 : 0;
                while (col >= 0 && col < cols)
                {
                    targetPractice[row, col] = snake[index % len];
                    col += updateCol;
                    index++;
                }

                isMoveLeft = !isMoveLeft;
            }
        }
    }
}
