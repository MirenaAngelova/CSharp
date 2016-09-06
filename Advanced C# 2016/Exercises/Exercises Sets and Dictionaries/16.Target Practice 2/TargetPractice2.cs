using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Target_Practice_2
{
    public class TargetPractice2
    {
        private const int BoundsCount = 4;
        private static int rows;
        private static int cols;
        private static char[,] targetPractice;
        private static string snake;

        private static int lowerBoundRow;
        private static int upperBoundRow;
        private static int lowerBoundCol;
        private static int upperBoundCol;
                                        
        public static void Main()
        {
            

            string[] rowsCols = Console.ReadLine().Split();
            rows = int.Parse(rowsCols[0]);
            cols = int.Parse(rowsCols[1]);

            targetPractice = new char[rows, cols];
            snake = Console.ReadLine();
            FillMatrix();

            string[] commands = Console.ReadLine().Split();
            BlastedSnake(commands);
            FallingDownSnakeRemains();
            PrintMatrix();
        }

        private static void PrintMatrix()
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

        private static void FallingDownSnakeRemains()
        {
            for (int row = upperBoundRow - 1; row >= 0; row--)
            {
                for (int col = upperBoundCol; col >= lowerBoundCol; col--)
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

        private static void BlastedSnake(string[] commands)
        {
            int impactRow = int.Parse(commands[0]);
            int impactCol = int.Parse(commands[1]);
            int radius = int.Parse(commands[2]);

            lowerBoundRow = Math.Max(0, impactRow - radius);
            upperBoundRow = Math.Min(rows - 1, impactRow + radius);
            lowerBoundCol = Math.Max(0, impactCol - radius);
            upperBoundCol = Math.Min(cols - 1, impactCol + radius);

            targetPractice[impactRow, impactCol] = ' ';

            for (int row = lowerBoundRow; row <= upperBoundRow; row++)
            {
                for (int col = lowerBoundCol; col <= upperBoundCol; col++)
                {
                    double distance = Math.Sqrt(
                        (row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol));
                    if (distance <= radius &&
                        targetPractice[row, col] != targetPractice[impactRow, impactCol])
                    {
                        targetPractice[row, col] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix()
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
