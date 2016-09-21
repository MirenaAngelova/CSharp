using System;
using System.Linq;
class BunkerBuster
{
    private static int impactRow;
    private static int impactCol;
    private static int impactPower;
    private static double reducedPower;
    private static int destroyedBunkers = 0;
    private static double damageDone = 0;
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        int[][] field = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            field[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "cease fire!")
            {
                break;
            }

            string[] bombsFormat = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            impactRow = int.Parse(bombsFormat[0]);
            impactCol = int.Parse(bombsFormat[1]);
            impactPower = (int)bombsFormat[2][0];

            reducedPower = Math.Round((double)impactPower / 2, 0, MidpointRounding.AwayFromZero);

            Bombardment(rows, cols, field);
        }

        DestroyedBunkers(rows, cols, field);

        damageDone = (double)destroyedBunkers / ((double)rows * cols) * 100;

        Console.WriteLine("Destroyed bunkers: {0}", destroyedBunkers);
        Console.WriteLine("Damage done: {0:f1} %", damageDone);
    }
    private static void Bombardment(int rows, int cols, int[][] field)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (!IsInTargetArea(i, j, impactRow, impactCol))
                {
                    continue;
                }
                if (i == impactRow && j == impactCol)
                {
                    field[i][j] -= impactPower;
                }
                else
                {
                    field[i][j] -= (int)reducedPower;
                }
            }
        }
    }
    private static bool IsInTargetArea(int i, int j, int impactRow, int impactCol)
    {
        return
            (i >= impactRow - 1 && i <= impactRow + 1) &&
            (j >= impactCol - 1 && j <= impactCol + 1);
    }
    private static void DestroyedBunkers(int rows, int cols, int[][] field)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (field[i][j] <= 0)
                {
                    destroyedBunkers++;
                }
            }
        }
    }
}