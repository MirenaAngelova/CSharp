using System;
class BunkerBuster
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        int[,] field = new int[rows, cols];

        FillField(rows, cols, field);

        string command = Console.ReadLine();

        Bombardment(rows, cols, field, command);

        int destroyedBunkers = DestroyedBunkers(field);

        double damageDone = (double)destroyedBunkers / ((double)rows * cols) * 100;

        Console.WriteLine("Destroyed bunkers: {0}", destroyedBunkers);

        Console.WriteLine("Damage done: {0:f1} %", damageDone);



    }
    private static void FillField(int rows, int cols, int[,] field)
    {
        for (int i = 0; i < rows; i++)
        {
            string[] strengthCell = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < cols; j++)
            {
                field[i, j] = int.Parse(strengthCell[j]);
            }
        }
    }
    private static void Bombardment(int rows, int cols, int[,] field, string command)
    {
        while (command != "cease fire!")
        {
            string[] formatBomb = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int impactRow = int.Parse(formatBomb[0]);
            int impactCol = int.Parse(formatBomb[1]);
            int power = char.Parse(formatBomb[2]);

            field[impactRow, impactCol] -= power;

            int reducedPower = (int)Math.Ceiling((double)power / 2);

            DestroyedAdjacentCells(rows, cols, field, impactRow, impactCol, reducedPower);

            command = Console.ReadLine();
        }
    }
    private static void DestroyedAdjacentCells(int rows, int cols, int[,] field, 
        int impactRow, int impactCol, int reducedPower)
    {
        int startRow = Math.Max(0, impactRow - 1);
        int endRow = Math.Min(rows - 1, impactRow + 1);

        int startCol = Math.Max(0, impactCol - 1);
        int endCol = Math.Min(cols - 1, impactCol + 1);

        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                if (i == impactRow && j == impactCol)
                {
                    continue;
                }

                field[i, j] -= reducedPower;
            }
        }
    }
    private static int DestroyedBunkers(int[,] field)
    {   
        int destroyedCells = 0;

        foreach (int cell in field)
        {
            if (cell <= 0)
            {
                destroyedCells++;
            }
        }

        return destroyedCells;
    }
}