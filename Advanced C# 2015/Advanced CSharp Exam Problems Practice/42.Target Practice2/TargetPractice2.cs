using System;
using System.Linq;
class TargetPractice
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        char[][] matrix = new char[rows][];

        string snake = Console.ReadLine();

        string[] parameters = Console.ReadLine().Split(' ');
        int impactRow = int.Parse(parameters[0]);
        int impactCol = int.Parse(parameters[1]);
        int radius = int.Parse(parameters[2]);

        Fill(matrix, snake, cols);

        Shot(matrix, impactRow, impactCol, radius);

        FallingDown(matrix);

        Print(matrix);
    }
    private static void Fill(char[][] matrix, string snake, int cols)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new char[cols];
        }

        bool isMoveLeft = true;
        int index = 0;

        for (int i = matrix.Length - 1; i >= 0; i--)
        {
            int j = isMoveLeft ? cols - 1 : 0;
            int jUpdate = isMoveLeft ? -1 : 1;

            while (j >= 0 && j < cols)
            {

                if (index >= snake.Length)
                {
                    index = 0;
                }

                matrix[i][j] = snake[index];

                j += jUpdate;
                index++;
            }

            isMoveLeft = !isMoveLeft;
        }
    }

    private static void Shot(char[][] matrix, int impactRow, int impactCol, int radius)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (((i - impactRow) * (i - impactRow) + (j - impactCol) * (j - impactCol)) <= radius * radius)
                {
                    matrix[i][j] = ' ';
                }
            }
        }
    }

    private static void FallingDown(char[][] matrix)
    {
        for (int i = matrix.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] != ' ')
                {
                    continue;
                }
                else
                {
                    int cur = i - 1;
                    while (cur >= 0)
                    {
                        if (matrix[cur][j] != ' ')
                        {
                            matrix[i][j] = matrix[cur][j];
                            matrix[cur][j] = ' ';
                            break;
                        }
                        cur--;
                    }
                }
            }
        }
    }

    private static void Print(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write(matrix[i][j]);
            }

            Console.WriteLine();
        }
    }
}