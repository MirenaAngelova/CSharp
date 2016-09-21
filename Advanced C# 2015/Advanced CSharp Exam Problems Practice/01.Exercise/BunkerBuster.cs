using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class BunkerBuster
{
    static void Main()
    {
        int[] rowsCols = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = rowsCols[0];
        int cols = rowsCols[1];

        int[,] matrix = new int[rows, cols];
        FillMatrix(matrix, rows, cols);
        
        string inputLine = Console.ReadLine();
        while (inputLine != "cease fire!")
        {
            string[] input = inputLine.Split();
            int impactRow = int.Parse(input[0]);
            int impactCol = int.Parse(input[1]);
            char impactPower = char.Parse(input[2]);

            int power = (int)impactPower;
            matrix[impactRow, impactCol] -= power;

            int halfPower = (int)Math.Ceiling((double)power / 2.0);

            ImpactAdjacentCells(matrix, rows, cols, impactRow, impactCol, halfPower);

            inputLine = Console.ReadLine();
        }

        int destroyedCells = DestroyedCells(matrix, rows, cols);
        Console.WriteLine($"Destroyed bunkers: {destroyedCells}");

        double damageDone = (double)destroyedCells / (double)(rows * cols) * 100.0;
        Console.WriteLine($"Damage done: {damageDone:F1} %");


    }

    private static void FillMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            int[] cells = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = cells[j];
            }
        }
    }

    private static void ImpactAdjacentCells(
        int[,] matrix, int rows, int cols, int impactRow, int impactCol, int halfPower)
    {
        int starRow = Math.Max(0, impactRow - 1);
        int endRow = Math.Min(rows - 1, impactRow + 1);

        int startCol = Math.Max(0, impactCol - 1);
        int endCol = Math.Min(cols - 1, impactCol + 1);

        for (int i = starRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (i == impactRow && j == impactCol)
                {
                    continue;
                }

                matrix[i, j] -= halfPower;
            }
        }
    }

    private static int DestroyedCells(int[,] matrix, int rows, int cols)
    {
        int destroyedCells = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] <= 0)
                {
                    destroyedCells++;
                }
            }
        }
        return destroyedCells;
    }

}


